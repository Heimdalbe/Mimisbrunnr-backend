using System.Security.Claims;
using Ardalis.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Mimisbrunnr.Domain.Games;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Persistence.Migrations;
using Mimisbrunnr.Services.Games;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Games;
using Xunit;

namespace Mimisbrunnr.Tests;

public class SnakeTests : IAsyncLifetime
{
    private readonly SqliteConnection connection = new("Data Source=:memory:");
    private ApplicationDbContext db = null!;
    private readonly Session session = new();
    private SnakeService service = null!;

    public async Task InitializeAsync()
    {
        await connection.OpenAsync();
        db = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options);
        await db.Database.EnsureCreatedAsync();
        db.Users.AddRange(new IdentityUser { Id = "a", UserName = "DragonRider" },
            new IdentityUser { Id = "b", UserName = "Heimie" });
        await db.SaveChangesAsync();
        session.User = Principal("a");
        service = new SnakeService(db, session);
    }

    [Fact]
    public async Task PublicLeaderboardShowsOnlyPersonalBestsForThatBoard()
    {
        await Submit(10);
        await Submit(4);
        await Submit(10);
        Assert.Single(await db.SnakeScores.ToListAsync());
        session.User = Principal("b");
        await Submit(12);
        await service.Submit(new() { Width = 40, Height = 40, Score = 100 }, default);
        session.User = null;
        var entries = (await service.GetLeaderboard(new() { Width = 20, Height = 16 }, default)).Value;
        Assert.Equal(new[] { new SnakeLeaderboardEntry("Heimie", 12), new SnakeLeaderboardEntry("DragonRider", 10) }, entries);
    }

    [Fact]
    public async Task PersistedScoresUseCurrentAccountUsername()
    {
        await Submit(10);
        (await db.Users.FindAsync("a"))!.UserName = "NewName";
        await db.SaveChangesAsync();
        await using var reloaded = new ApplicationDbContext(
            new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options);
        var entries = (await new SnakeService(reloaded, new Session())
            .GetLeaderboard(new() { Width = 20, Height = 16 }, default)).Value;
        Assert.Equal(new SnakeLeaderboardEntry("NewName", 10), Assert.Single(entries));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("missing")]
    public async Task ScoreRequiresAnExistingAuthenticatedUser(string? userId)
    {
        session.User = userId is null ? null : Principal(userId);
        Assert.Equal(ResultStatus.Unauthorized, (await Submit(5)).Status);
        Assert.Empty(await db.SnakeScores.ToListAsync());
    }

    [Theory]
    [InlineData(0, 20, 16)]
    [InlineData(-1, 20, 16)]
    [InlineData(318, 20, 16)]
    [InlineData(5, 7, 16)]
    [InlineData(5, 20, 41)]
    public async Task InvalidScoresAndBoardSizesAreRejected(int score, int width, int height)
    {
        var result = await service.Submit(new() { Width = width, Height = height, Score = score }, default);
        Assert.Equal(ResultStatus.Invalid, result.Status);
        Assert.Empty(await db.SnakeScores.ToListAsync());
    }

    [Theory]
    [InlineData(8, 8)]
    [InlineData(40, 40)]
    public async Task FullBoardScoresAreAcceptedAtBothSizeLimits(int width, int height)
    {
        Assert.True((await service.Submit(new()
            { Width = width, Height = height, Score = width * height - 3 }, default)).IsSuccess);
    }

    [Fact]
    public async Task TopTenIsBoundedWithDeterministicTies()
    {
        for (var i = 0; i < 12; i++)
        {
            var id = $"player{i:D2}";
            db.Users.Add(new IdentityUser { Id = id, UserName = id });
            db.SnakeScores.Add(new SnakeScore { UserId = id, Width = 20, Height = 16, Score = 20 });
        }
        await db.SaveChangesAsync();
        var entries = (await service.GetLeaderboard(new() { Width = 20, Height = 16 }, default)).Value;
        Assert.Equal(10, entries.Count);
        Assert.Equal("player00", entries[0].Username);
        Assert.Equal("player09", entries[9].Username);
    }

    [Fact]
    public void MigrationCreatesMysqlTableAndForeignKey()
    {
        using var context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySql("Server=localhost;Database=test", new MariaDbServerVersion(new Version(10, 11, 6))).Options);
        var commands = context.GetService<IMigrationsSqlGenerator>().Generate(new AddSnakeScores().UpOperations);
        var sql = string.Join("\n", commands.Select(c => c.CommandText));
        Assert.Contains("CREATE TABLE `SnakeScores`", sql);
        Assert.Contains($"REFERENCES `{context.Model.FindEntityType(typeof(IdentityUser))!.GetTableName()}` (`Id`) ON DELETE CASCADE", sql);
    }

    private Task<Result> Submit(int score) =>
        service.Submit(new() { Width = 20, Height = 16, Score = score }, default);

    private static ClaimsPrincipal Principal(string userId) =>
        new(new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, userId)], "test"));

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
