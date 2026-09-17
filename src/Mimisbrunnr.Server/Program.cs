using System.Net.Http.Headers;
using Destructurama;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Accounts;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Persistence.Triggers;
using Mimisbrunnr.Server.Identity;
using Mimisbrunnr.Server.Processors;
using Mimisbrunnr.Services;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Identity;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger(); // Initial log setup, will be overwritten by Serilog, but we need a logger before Dependency Injection is activated.

try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);
    
    builder.Services
        .AddSerilog((_, lc) => lc.ReadFrom.Configuration(builder.Configuration) // Configuration in AppSettings.json
            .Destructure.UsingAttributes()) // Sensitive data logging
        .AddCors(options =>
        {
            options.AddPolicy("Frontend", policy =>
            {
                var allowedOrigin = builder.Configuration["Frontend:Origin"]
                                    ?? throw new InvalidOperationException("Frontend:Origin not configured.");
                policy.WithOrigins(allowedOrigin)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        })
        .AddIdentity<IdentityUser, IdentityRole>() 
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders()
        
        .Services.AddHttpClient("SecureApi", c =>
        {
            var imgurClientId = builder.Configuration.GetSection("imgur")["Client-Id"];
            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", imgurClientId);
        })
        .Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SecureApi"))
        
        .AddDbContext<ApplicationDbContext>(o =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'DatabaseConnection' not found.");

            o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            o.EnableDetailedErrors();
            if (builder.Environment.IsDevelopment())
                o.EnableSensitiveDataLogging();

            o.AddApplicationTriggers();
        })
        .ConfigureApplicationCookie(o =>
        {
            o.Cookie.SameSite = SameSiteMode.None;
            o.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            o.Events.OnRedirectToLogin = ctx =>
            {
                ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            };

            o.Events.OnRedirectToAccessDenied = ctx =>
            {
                ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                return Task.CompletedTask;
            };
        })
        .AddHttpContextAccessor()
        .AddScoped<ISessionContextProvider, HttpContextSessionProvider>() // Provides the current user from the HttpContext to the session provider.
        .AddApplicationServices() // You'll need to add your own services in this function call.
        .AddAuthorization()
        .AddFastEndpoints(o =>
        {
            o.IncludeAbstractValidators = true; // Include validators from abstract classes (see https://docs.fluentvalidation.net/en/latest/).
            //o.Assemblies = [typeof(ProductRequest).Assembly]; // Adds the validators from other assemblies
        })
        .SwaggerDocument(o =>
        {
            o.DocumentSettings = s =>
            {
                s.Title = "MIMMISBRUNNR API";
            };
        });

    builder.Services.Configure<ForwardedHeadersOptions>(options =>
    {
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        options.KnownNetworks.Clear();
        options.KnownProxies.Clear();
    });
    var app = builder.Build();
    // apply Database migraticons on startup, not so wise in production (Use Generated SQL Scripts) 
    // See: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli
    if (app.Environment.IsDevelopment())
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var dbSeeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
        dbContext.Database.EnsureDeleted();
        await dbContext.Database.EnsureCreatedAsync();
        await dbSeeder.SeedAsync();
    }
    else
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();

    if (builder.Configuration.GetValue<bool>("Seed:Accounts"))
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        const string defaultPassword = "A1b2C3!";

        var accounts = new (string Email, string[] Roles)[]
        {
            ("vice-praeses@heimdal.be",     new[] { AppRoles.Commilitones }),
            ("quaestor@heimdal.be",         new[] { AppRoles.Commilitones }),
            ("media@heimdal.be",            new[] { AppRoles.Commilitones, AppRoles.MediaEditor }),
            ("feest-lan@heimdal.be",        new[] { AppRoles.Commilitones, AppRoles.EventEditor }),
            ("sport@heimdal.be",            new[] { AppRoles.Commilitones, AppRoles.EventEditor }),
            ("pr@heimdal.be",               new[] { AppRoles.Commilitones, AppRoles.SponsorEditor, AppRoles.EventEditor }),
            ("secretaris@heimdal.be",       new[] { AppRoles.Commilitones }),
            ("cultuur@heimdal.be",          new[] { AppRoles.Commilitones, AppRoles.EventEditor }),
            ("ict@heimdal.be",              new[] { AppRoles.Commilitones, AppRoles.Hmdl }),
            ("praeses@heimdal.be",          new[] { AppRoles.Commilitones, AppRoles.Hmdl }),
            ("schachtentemmer@heimdal.be",  new[] { AppRoles.Commilitones, AppRoles.EventEditor }),
        };

        foreach (var role in accounts.SelectMany(a => a.Roles).Distinct())
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        foreach (var (email, roles) in accounts)
        {
            if (await userManager.FindByEmailAsync(email) is not null)
                continue;

            var userName = email.Split('@')[0];
            var user = new IdentityUser { UserName = userName, Email = email, EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, defaultPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(user, roles);

                dbContext.Set<Account>().Add(new Account(userName, email, user.Id));
                await dbContext.SaveChangesAsync();

                Log.Warning("Seeded {Email} with roles {Roles}", email, string.Join(", ", roles));
            }
            else
            {
                Log.Warning("Failed to seed {Email}: {Errors}",
                    email, string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
    // Theses middlewares are strict in order of calling!
    app.UseForwardedHeaders()
        .UseHttpsRedirection()
        //.UseBlazorFrameworkFiles() // Blazor is also served from the API. 
        //.UseStaticFiles()
        .UseDefaultExceptionHandler()
        .UseCors("Frontend")
        .UseAuthentication()
        .UseAuthorization()
        .UseFastEndpoints(o =>
        {
            o.Endpoints.Configurator = ep =>
            {
                ep.DontAutoSendResponse();
                ep.PreProcessor<GlobalRequestLogger>(Order.Before);
                ep.PostProcessor<GlobalResponseSender>(Order.Before);
                ep.PostProcessor<GlobalResponseLogger>(Order.Before);
            };
        })
        .UseSwaggerGen();
    //app.MapFallbackToFile("index.html"); // Serves the Blazor app from the API, when no routes match.
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
}
finally
{
    Log.CloseAndFlush();
}


