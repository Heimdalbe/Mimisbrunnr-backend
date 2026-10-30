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
using Mimisbrunnr.Shared.Accounts;
using Xunit;

namespace Mimisbrunnr.Tests;

public class AccountNamesTests : IAsyncLifetime
{
    private readonly SqliteConnection connection = new("Data Source=:memory:");
    private ServiceProvider services = null!;
    private ApplicationDbContext db = null!;
    private UserManager<IdentityUser> users = null!;
    private AccountService accounts = null!;
    private Account member = null!;
    private Account other = null!;

    public async Task InitializeAsync()
    {
        await connection.OpenAsync();
        var collection = new ServiceCollection();
        collection.AddLogging();
        collection.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(connection));
        collection.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
        services = collection.BuildServiceProvider();
        db = services.GetRequiredService<ApplicationDbContext>();
        users = services.GetRequiredService<UserManager<IdentityUser>>();
        await db.Database.EnsureCreatedAsync();
        member = await AddAccount("member");
        other = await AddAccount("other");
        accounts = new AccountService(db, new Session(member.UserId), users);
    }

    [Fact]
    public async Task ExistingAccountWithoutNamesStillLoadsAndUpdates()
    {
        var profile = (await accounts.GetAccountBySelf(default)).Value;
        Assert.Equal("member", profile.Name);
        Assert.Null(profile.FirstName);
        Assert.Null(profile.LastName);
        Assert.True((await accounts.PutAccountBySelf(new() { Name = "renamed" }, default)).IsSuccess);
        Assert.Equal("renamed", (await users.FindByIdAsync(member.UserId))!.UserName);
    }

    [Fact]
    public async Task SelfAndAdminCanSaveTheSamePersonalNamesForDifferentAccounts()
    {
        var names = new AccountRequest.PutAccount { FirstName = "  Zoë  ", LastName = "  De Smet  " };
        Assert.True((await accounts.PutAccountBySelf(names, default)).IsSuccess);
        Assert.True((await accounts.PutAccountById(other.Id, names, default)).IsSuccess);
        db.ChangeTracker.Clear();

        foreach (var profile in (await accounts.GetAccounts(default)).Value.Accounts)
        {
            Assert.Equal("Zoë", profile.FirstName);
            Assert.Equal("De Smet", profile.LastName);
        }
        var detailed = (await accounts.GetAccount(other.Id, default)).Value;
        Assert.Equal("other", detailed.Name);
        Assert.Equal("De Smet", detailed.LastName);
    }

    [Fact]
    public async Task PersonalNameEditDoesNotRotateCredentialsWhenUsernameAndEmailAreUnchanged()
    {
        var before = (await users.FindByIdAsync(member.UserId))!.SecurityStamp;
        var result = await accounts.PutAccountBySelf(new()
        {
            Name = member.Name,
            Email = member.Email.Address,
            FirstName = "Zoë",
            LastName = "De Smet"
        }, default);

        Assert.True(result.IsSuccess);
        Assert.Equal(before, (await users.FindByIdAsync(member.UserId))!.SecurityStamp);
    }

    [Fact]
    public async Task OmittedNamesStayUnchangedAndEmptyNamesCanBeCleared()
    {
        await accounts.PutAccountBySelf(new() { FirstName = "Zoë", LastName = "De Smet" }, default);
        await accounts.PutAccountBySelf(new() { Name = "renamed" }, default);
        Assert.Equal("Zoë", (await accounts.GetAccountBySelf(default)).Value.FirstName);
        await accounts.PutAccountBySelf(new() { FirstName = "", LastName = "  " }, default);
        db.ChangeTracker.Clear();
        var profile = (await accounts.GetAccountBySelf(default)).Value;
        Assert.Null(profile.FirstName);
        Assert.Null(profile.LastName);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task DuplicateUsernameIsRejectedWithoutChangingProfile(bool admin)
    {
        var request = new AccountRequest.PutAccount { Name = "OTHER", FirstName = "Changed" };
        var result = admin
            ? await accounts.PutAccountById(member.Id, request, default)
            : await accounts.PutAccountBySelf(request, default);

        Assert.Equal(ResultStatus.Invalid, result.Status);
        Assert.Equal("Name", Assert.Single(result.ValidationErrors).Identifier);
        db.ChangeTracker.Clear();
        Assert.Equal("member", (await accounts.GetAccount(member.Id, default)).Value.Name);
        Assert.Null((await accounts.GetAccount(member.Id, default)).Value.FirstName);
        Assert.Equal("member", (await users.FindByIdAsync(member.UserId))!.UserName);
    }

    [Theory]
    [InlineData(null, null, true)]
    [InlineData("Zoë", "De Smet", true)]
    [InlineData("", "", true)]
    [InlineData("long", "", false)]
    public void PersonalNameLengthIsValidated(string? firstName, string? lastName, bool valid)
    {
        if (firstName == "long") firstName = new string('x', 101);
        var result = new AccountRequest.PutAccount.Validator().Validate(new AccountRequest.PutAccount
        {
            FirstName = firstName,
            LastName = lastName
        });
        Assert.Equal(valid, result.IsValid);
    }

    private async Task<Account> AddAccount(string name)
    {
        var user = new IdentityUser { UserName = name, Email = $"{name}@example.test" };
        Assert.True((await users.CreateAsync(user)).Succeeded);
        var account = new Account(name, user.Email, user.Id);
        db.Accounts.Add(account);
        await db.SaveChangesAsync();
        return account;
    }

    public async Task DisposeAsync()
    {
        await services.DisposeAsync();
        await connection.DisposeAsync();
    }

    private sealed class Session(string id) : ISessionContextProvider
    {
        public ClaimsPrincipal? User => new(new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, id)], "test"));
    }
}
