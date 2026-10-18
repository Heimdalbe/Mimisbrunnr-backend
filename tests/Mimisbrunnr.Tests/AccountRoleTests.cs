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
using Mimisbrunnr.Shared.Identity;
using Xunit;

namespace Mimisbrunnr.Tests;

public class AccountRoleTests : IAsyncLifetime
{
    private readonly SqliteConnection connection = new("Data Source=:memory:");
    private ServiceProvider services = null!;
    private IServiceScope scope = null!;
    private ApplicationDbContext db = null!;
    private UserManager<IdentityUser> users = null!;
    private AccountRoleService roles = null!;
    private readonly Session session = new();
    private IdentityUser admin = null!;
    private IdentityUser member = null!;
    private int adminId;
    private int memberId;

    public async Task InitializeAsync()
    {
        await connection.OpenAsync();
        var collection = new ServiceCollection();
        collection.AddLogging();
        collection.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(connection));
        collection.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services = collection.BuildServiceProvider();
        scope = services.CreateScope();
        db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        users = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await db.Database.EnsureCreatedAsync();
        foreach (var name in new[] { AppRoles.Hmdl, AppRoles.Commilitones, AppRoles.EventEditor, AppRoles.MediaEditor })
            Assert.True((await roleManager.CreateAsync(new IdentityRole(name))).Succeeded);
        admin = new IdentityUser { UserName = "admin", Email = "admin@example.test" };
        member = new IdentityUser { UserName = "member", Email = "member@example.test" };
        Assert.True((await users.CreateAsync(admin)).Succeeded);
        Assert.True((await users.CreateAsync(member)).Succeeded);
        Assert.True((await users.AddToRoleAsync(admin, AppRoles.Hmdl)).Succeeded);
        Assert.True((await users.AddToRolesAsync(member, [AppRoles.Commilitones, AppRoles.MediaEditor])).Succeeded);
        var adminAccount = new Account("admin", admin.Email, admin.Id);
        var memberAccount = new Account("member", member.Email, member.Id);
        db.Accounts.AddRange(adminAccount, memberAccount);
        await db.SaveChangesAsync();
        adminId = adminAccount.Id;
        memberId = memberAccount.Id;
        session.User = Principal(admin.Id, AppRoles.Hmdl);
        roles = new AccountRoleService(db, session, users, roleManager);
    }

    [Fact]
    public async Task ReadsAssignedRolesAndIdentifiesOwnAccount()
    {
        var own = await roles.GetRoles(adminId, default);
        var other = await roles.GetRoles(memberId, default);
        Assert.True(own.Value.IsCurrentUser);
        Assert.False(other.Value.IsCurrentUser);
        Assert.Equal(new[] { AppRoles.Commilitones, AppRoles.MediaEditor }, other.Value.Roles);
    }

    [Fact]
    public async Task AddsAndRemovesRolesTogether()
    {
        var result = await Update(memberId, AppRoles.Commilitones, AppRoles.EventEditor);
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal(new[] { AppRoles.Commilitones, AppRoles.EventEditor }, result.Value.Roles);
        Assert.Equal(result.Value.Roles, (await roles.GetRoles(memberId, default)).Value.Roles);
    }

    [Fact]
    public async Task AcceptsEmptyRoleSetForAnotherAccount()
    {
        Assert.Equal(ResultStatus.Ok, (await Update(memberId)).Status);
        Assert.Empty(await users.GetRolesAsync(member));
    }

    [Fact]
    public async Task CanonicalizesCaseAndDuplicates()
    {
        var result = await Update(memberId, "eventeditor", "EVENTEDITOR");
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal(new[] { AppRoles.EventEditor }, result.Value.Roles);
    }

    [Fact]
    public async Task UnknownRoleDoesNotChangeAssignments()
    {
        var result = await Update(memberId, AppRoles.EventEditor, "DoesNotExist");
        Assert.Equal(ResultStatus.Invalid, result.Status);
        Assert.Equal(new[] { AppRoles.Commilitones, AppRoles.MediaEditor },
            (await users.GetRolesAsync(member)).OrderBy(r => r));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task RejectsInvalidRoleNames(string? name)
    {
        Assert.Equal(ResultStatus.Invalid, (await Update(memberId, name!)).Status);
        Assert.Equal(2, (await users.GetRolesAsync(member)).Count);
    }

    [Fact]
    public async Task RejectsMissingRoleList()
    {
        var result = await roles.PutRoles(memberId, new() { Roles = null! }, default);
        Assert.Equal(ResultStatus.Invalid, result.Status);
    }

    [Fact]
    public async Task CannotRemoveOwnAdminAccess()
    {
        Assert.Equal(ResultStatus.Conflict, (await Update(adminId, AppRoles.Commilitones)).Status);
        Assert.True(await users.IsInRoleAsync(admin, AppRoles.Hmdl));
    }

    [Fact]
    public async Task CanEditOwnOtherRolesWhileKeepingAdminAccess()
    {
        Assert.Equal(ResultStatus.Ok, (await Update(adminId, AppRoles.Hmdl, AppRoles.EventEditor)).Status);
        Assert.True(await users.IsInRoleAsync(admin, AppRoles.EventEditor));
    }

    [Fact]
    public async Task NonAdminCannotReadOrChangeRoles()
    {
        session.User = Principal(member.Id, AppRoles.EventEditor);
        Assert.Equal(ResultStatus.Forbidden, (await roles.GetRoles(adminId, default)).Status);
        Assert.Equal(ResultStatus.Forbidden, (await Update(memberId, AppRoles.Hmdl)).Status);
        Assert.False(await users.IsInRoleAsync(member, AppRoles.Hmdl));
    }

    [Fact]
    public async Task AnonymousCannotReadOrChangeRoles()
    {
        session.User = null;
        Assert.Equal(ResultStatus.Forbidden, (await roles.GetRoles(memberId, default)).Status);
        Assert.Equal(ResultStatus.Forbidden, (await Update(memberId, AppRoles.Hmdl)).Status);
    }

    [Fact]
    public async Task MissingAccountReturnsNotFound()
    {
        Assert.Equal(ResultStatus.NotFound, (await roles.GetRoles(int.MaxValue, default)).Status);
        Assert.Equal(ResultStatus.NotFound, (await Update(int.MaxValue, AppRoles.Hmdl)).Status);
    }

    [Fact]
    public async Task MissingIdentityUserReturnsNotFound()
    {
        var orphan = new Account("orphan", "orphan@example.test", "missing-user");
        db.Accounts.Add(orphan);
        await db.SaveChangesAsync();
        Assert.Equal(ResultStatus.NotFound, (await roles.GetRoles(orphan.Id, default)).Status);
        Assert.Equal(ResultStatus.NotFound, (await Update(orphan.Id, AppRoles.Hmdl)).Status);
    }

    [Fact]
    public async Task IdentityConcurrencyFailureRollsBackAddedAndRemovedRoles()
    {
        // Load a stale user into this context, then change its stamp through a separate scope.
        await using (var second = services.CreateAsyncScope())
        {
            var manager = second.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var fresh = (await manager.FindByIdAsync(member.Id))!;
            Assert.True((await manager.UpdateAsync(fresh)).Succeeded);
        }
        Assert.Equal(ResultStatus.Conflict, (await Update(memberId, AppRoles.EventEditor)).Status);
        db.ChangeTracker.Clear();
        var reloaded = (await users.FindByIdAsync(member.Id))!;
        Assert.Equal(new[] { AppRoles.Commilitones, AppRoles.MediaEditor },
            (await users.GetRolesAsync(reloaded)).OrderBy(r => r));
    }

    private Task<Result<AccountRoles>> Update(int id, params string[] names) =>
        roles.PutRoles(id, new AccountRequest.PutAccountRoles { Roles = names.ToList() }, default);

    private static ClaimsPrincipal Principal(string id, string role) => new(new ClaimsIdentity(
        [new Claim(ClaimTypes.NameIdentifier, id), new Claim(ClaimTypes.Role, role)], "test"));

    public async Task DisposeAsync()
    {
        scope.Dispose();
        await services.DisposeAsync();
        await connection.DisposeAsync();
    }

    private sealed class Session : ISessionContextProvider
    {
        public ClaimsPrincipal? User { get; set; }
    }
}
