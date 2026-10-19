using System.Security.Claims;
using Ardalis.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mimisbrunnr.Domain.Accounts;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Accounts;
using Mimisbrunnr.Services.Identity;
using Xunit;

namespace Mimisbrunnr.Tests;

public class AccountPasswordTests : IAsyncLifetime
{
    private const string OldPassword = "OldPassword1!";
    private const string NewPassword = "NewPassword2!";
    private readonly SqliteConnection connection = new("Data Source=:memory:");
    private ServiceProvider services = null!;
    private IServiceScope scope = null!;
    private ApplicationDbContext db = null!;
    private UserManager<IdentityUser> users = null!;
    private IdentityUser user = null!;
    private AccountService accounts = null!;
    private int accountId;

    public async Task InitializeAsync()
    {
        await connection.OpenAsync();
        var collection = new ServiceCollection();
        collection.AddLogging();
        collection.AddDataProtection();
        collection.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(connection));
        collection.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services = collection.BuildServiceProvider();
        scope = services.CreateScope();
        db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        users = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        await db.Database.EnsureCreatedAsync();
        user = new IdentityUser { UserName = "member", Email = "member@example.test" };
        Assert.True((await users.CreateAsync(user, OldPassword)).Succeeded);
        var account = new Account("member", user.Email, user.Id);
        db.Accounts.Add(account);
        await db.SaveChangesAsync();
        accountId = account.Id;
        accounts = new AccountService(db, new Session(user.Id), users);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("wrong")]
    public async Task MissingOrWrongCurrentPasswordLeavesPasswordAndProfileUnchanged(string? current)
    {
        var result = await accounts.PutAccountBySelf(new() { CurrentPassword = current, Password = NewPassword, Name = "changed" }, default);
        Assert.Equal(ResultStatus.Invalid, result.Status);
        Assert.Equal("CurrentPassword", Assert.Single(result.ValidationErrors).Identifier);
        Assert.True(await users.CheckPasswordAsync(user, OldPassword));
        Assert.False(await users.CheckPasswordAsync(user, NewPassword));
        Assert.Equal("member", (await db.Accounts.FindAsync(accountId))!.Name);
    }

    [Fact]
    public async Task CorrectCurrentPasswordChangesPasswordAndSecurityStamp()
    {
        var oldStamp = user.SecurityStamp;
        var result = await accounts.PutAccountBySelf(new() { CurrentPassword = OldPassword, Password = NewPassword }, default);
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.True(await users.CheckPasswordAsync(user, NewPassword));
        Assert.False(await users.CheckPasswordAsync(user, OldPassword));
        Assert.NotEqual(oldStamp, user.SecurityStamp);
    }

    [Fact]
    public async Task InvalidNewPasswordDoesNotReportSuccessOrChangePassword()
    {
        var result = await accounts.PutAccountBySelf(new() { CurrentPassword = OldPassword, Password = "weak" }, default);
        Assert.Equal(ResultStatus.Invalid, result.Status);
        Assert.NotEmpty(result.ValidationErrors);
        Assert.True(await users.CheckPasswordAsync(user, OldPassword));
    }

    [Fact]
    public async Task ProfileUpdateDoesNotRequirePassword()
    {
        Assert.Equal(ResultStatus.Ok, (await accounts.PutAccountBySelf(new() { Name = "changed" }, default)).Status);
        Assert.Equal("changed", (await db.Accounts.FindAsync(accountId))!.Name);
        Assert.True(await users.CheckPasswordAsync(user, OldPassword));
    }

    [Fact]
    public async Task AdminResetDoesNotRequireCurrentPassword()
    {
        Assert.Equal(ResultStatus.Ok, (await accounts.PutAccountById(accountId, new() { Password = NewPassword }, default)).Status);
        Assert.True(await users.CheckPasswordAsync(user, NewPassword));
    }

    public async Task DisposeAsync()
    {
        scope.Dispose();
        await services.DisposeAsync();
        await connection.DisposeAsync();
    }

    private sealed class Session(string id) : ISessionContextProvider
    {
        public ClaimsPrincipal? User => new(new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, id)], "test"));
    }
}
