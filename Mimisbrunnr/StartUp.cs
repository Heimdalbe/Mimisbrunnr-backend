using Hangfire;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Data;
using Mimisbrunnr.Services.Instances;
using Mimisbrunnr.Services.Interfaces;

namespace Mimisbrunnr
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Context")).LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddHangfire(config => {
                config.UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("Hangfire"));
            });
            services.AddHangfireServer();

            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IEventService, EventService>();

            services.AddScoped<DataInit>();

            services.AddSwaggerGen();

            services.AddControllers();

            services.AddAuthorization(options =>
            { });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, DataInit init)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();
     
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireDashboard();

            init.Init().Wait();
        }
    }
}
