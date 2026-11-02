using System.Security.Claims;
using Ardalis.Result;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Persistence.Migrations;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Services.Membership;
using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Membership;
using Xunit;

namespace Mimisbrunnr.Tests;

public class MembershipFeesTests : IAsyncLifetime
{
    private readonly SqliteConnection connection = new("Data Source=:memory:");
    private ApplicationDbContext db = null!;
    private readonly Session session = new();
    private MembershipFeesService service = null!;

    public async Task InitializeAsync()
    {
        await connection.OpenAsync();
        db = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options);
        await db.Database.EnsureCreatedAsync();
        session.User = Principal(AppRoles.Hmdl);
        service = new MembershipFeesService(db, session);
    }

    [Fact]
    public void MigrationGeneratesMysqlTableAndInitialFees()
    {
        using var context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySql("Server=localhost;Database=test", new MariaDbServerVersion(new Version(10, 11, 6))).Options);
        var commands = context.GetService<IMigrationsSqlGenerator>().Generate(new AddMembershipFees().UpOperations);
        var sql = string.Join("\n", commands.Select(c => c.CommandText));
        Assert.Contains("CREATE TABLE `MembershipFees`", sql);
        Assert.Contains("INSERT INTO `MembershipFees`", sql);
        Assert.Contains("12.0", sql);
        Assert.Contains("7.0", sql);
    }

    [Fact]
    public async Task PublicReadReturnsInitialFees()
    {
        session.User = null;
        var result = await service.Get(default);
        Assert.Equal(12m, result.Value.FirstYearFee);
        Assert.Equal(7m, result.Value.RenewalFee);
    }

    [Fact]
    public async Task SavedFeesSurviveAContextReload()
    {
        Assert.Equal(ResultStatus.Ok, (await Update(14.50m, 8m)).Status);
        await using var reloaded = new ApplicationDbContext(
            new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options);
        var result = await new MembershipFeesService(reloaded, new Session()).Get(default);
        Assert.Equal(14.50m, result.Value.FirstYearFee);
        Assert.Equal(8m, result.Value.RenewalFee);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(AppRoles.Feut)]
    [InlineData(AppRoles.EventEditor)]
    [InlineData(AppRoles.SponsorEditor)]
    public async Task OnlyHmdlCanChangeFees(string? role)
    {
        session.User = role is null ? null : Principal(role);
        Assert.Equal(ResultStatus.Forbidden, (await Update(20m, 10m)).Status);
        Assert.Equal(12m, (await service.Get(default)).Value.FirstYearFee);
    }

    [Theory]
    [InlineData(null, 7d)]
    [InlineData(12d, null)]
    [InlineData(-1d, 7d)]
    [InlineData(12d, -1d)]
    [InlineData(10000d, 7d)]
    [InlineData(12d, 10000d)]
    [InlineData(12.345, 7d)]
    [InlineData(12d, 7.123)]
    public async Task InvalidFeesDoNotChangeStoredValues(double? first, double? renewal)
    {
        var result = await Update(first is null ? null : (decimal)first, renewal is null ? null : (decimal)renewal);
        Assert.Equal(ResultStatus.Invalid, result.Status);
        var stored = (await service.Get(default)).Value;
        Assert.Equal(12m, stored.FirstYearFee);
        Assert.Equal(7m, stored.RenewalFee);
    }

    [Fact]
    public async Task AllowsFreeMembershipAndTheUpperBoundary()
    {
        Assert.Equal(ResultStatus.Ok, (await Update(0m, 9999.99m)).Status);
        var stored = (await service.Get(default)).Value;
        Assert.Equal(0m, stored.FirstYearFee);
        Assert.Equal(9999.99m, stored.RenewalFee);
    }

    private Task<Result<MembershipFeesDto>> Update(decimal? first, decimal? renewal) =>
        service.Update(new UpdateMembershipFees { FirstYearFee = first, RenewalFee = renewal }, default);

    private static ClaimsPrincipal Principal(string role) =>
        new(new ClaimsIdentity([new Claim(ClaimTypes.Role, role)], "test"));

    private sealed class Session : ISessionContextProvider
    {
        public ClaimsPrincipal? User { get; set; }
    }

    public async Task DisposeAsync()
    {
        await db.DisposeAsync();
        await connection.DisposeAsync();
    }
}
