using System.Security.Claims;
using Ardalis.Result;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Events;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Events;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Identity;
using Xunit;

namespace Mimisbrunnr.Tests;

public class EventAccessTests : IAsyncLifetime
{
    private const string RegistrationUrl = "https://example.test/register";
    private readonly SqliteConnection connection = new("Data Source=:memory:");
    private ApplicationDbContext db = null!;
    private EventService events = null!;
    private readonly Session session = new();

    public async Task InitializeAsync()
    {
        await connection.OpenAsync();
        db = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options);
        await db.Database.EnsureCreatedAsync();
        events = new EventService(db, session);
    }

    public static IEnumerable<object?[]> Audiences()
    {
        foreach (var audience in new[] { Accessibility.OPEN, Accessibility.HEIMIES, Accessibility.CLOSED })
        foreach (var role in new[] { null, AppRoles.Feut, AppRoles.Heimie, AppRoles.Schacht, AppRoles.Commilitones, AppRoles.Hmdl, AppRoles.EventEditor })
        {
            var allowed = audience == Accessibility.OPEN || role == AppRoles.Hmdl ||
                role is AppRoles.Schacht or AppRoles.Commilitones ||
                audience == Accessibility.HEIMIES && role == AppRoles.Heimie;
            yield return [audience, role, allowed];
        }
    }

    [Theory]
    [MemberData(nameof(Audiences))]
    public async Task PublicDetailAndListEnforceAudienceWithoutChangingStoredLink(Accessibility audience, string? role, bool allowed)
    {
        session.User = role is null ? null : new ClaimsPrincipal(new ClaimsIdentity([new Claim(ClaimTypes.Role, role)], "test"));
        var e = await AddEvent(audience);
        var detail = await events.GetPublishedEvent(e.Id, default);
        var list = await events.GetPublishedEvents(new QueryRequest.SkipTake { Take = 100 }, default);
        var item = Assert.Single(list.Value.Events);
        Assert.Equal(ResultStatus.Ok, detail.Status);
        Assert.Equal(allowed ? RegistrationUrl : null, detail.Value.Url);
        Assert.Equal(allowed ? RegistrationUrl : null, item.Url);
        if (allowed)
            Assert.Null(detail.Value.RegistrationAccessError);
        else
        {
            Assert.False(string.IsNullOrWhiteSpace(detail.Value.RegistrationAccessError));
            if (role is null)
                Assert.Contains("Log in", detail.Value.RegistrationAccessError);
        }
        Assert.Equal(RegistrationUrl, e.Url);
        Assert.Equal(RegistrationUrl, (await events.GetEvent(e.Id, default)).Value.Url);
        Assert.Equal(allowed ? RegistrationUrl : null, (await events.GetOpenEvent(e.Id, default)).Value.Url);
        await db.SaveChangesAsync();
        db.ChangeTracker.Clear();
        Assert.Equal(RegistrationUrl, (await db.Events.FindAsync(e.Id))!.Url);
    }

    [Fact]
    public async Task UnauthenticatedRoleClaimsDoNotGrantAccess()
    {
        session.User = new ClaimsPrincipal(new ClaimsIdentity([new Claim(ClaimTypes.Role, AppRoles.Hmdl)]));
        var e = await AddEvent(Accessibility.CLOSED);
        Assert.Null((await events.GetPublishedEvent(e.Id, default)).Value.Url);
    }

    [Fact]
    public async Task UnpublishedEventsStayHiddenFromPublicEndpoints()
    {
        var e = await AddEvent(Accessibility.OPEN, published: false);
        Assert.Equal(ResultStatus.NotFound, (await events.GetPublishedEvent(e.Id, default)).Status);
        Assert.Empty((await events.GetPublishedEvents(new QueryRequest.SkipTake { Take = 100 }, default)).Value.Events);
    }

    [Fact]
    public async Task MissingRegistrationLinkDoesNotShowAccessError()
    {
        var e = await AddEvent(Accessibility.HEIMIES);
        e.Url = "https://heimdal.be";
        await db.SaveChangesAsync();
        Assert.Null((await events.GetPublishedEvent(e.Id, default)).Value.RegistrationAccessError);
    }

    [Theory]
    [InlineData("999")]
    [InlineData("UNKNOWN")]
    public async Task InvalidAudienceCannotBeSaved(string audience)
    {
        var e = await AddEvent(Accessibility.OPEN);
        Assert.Equal(ResultStatus.Invalid, (await events.PutEvent(e.Id, new() { Accessibility = audience }, default)).Status);
        Assert.Equal(Accessibility.OPEN, e.Accessibility);
        var request = Draft(audience);
        Assert.Equal(ResultStatus.Invalid, (await events.PostEvent(request, default)).Status);
        Assert.Equal(1, await db.Events.CountAsync());
    }

    [Theory]
    [InlineData("OPEN")]
    [InlineData("CLOSED")]
    [InlineData("HEIMIES")]
    public async Task AudienceCanBeCreatedAndEdited(string audience)
    {
        var result = await events.PostEvent(Draft(audience), default);
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal(audience, (await events.GetEvent(result.Value.Id, default)).Value.Accessibility);
        Assert.Equal(ResultStatus.Ok, (await events.PutEvent(result.Value.Id, new() { Accessibility = "HEIMIES" }, default)).Status);
        Assert.Equal("HEIMIES", (await events.GetEvent(result.Value.Id, default)).Value.Accessibility);
    }

    [Fact]
    public void ExistingStoredAudienceValuesKeepTheirMeaning()
    {
        Assert.Equal(0, (int)Accessibility.OPEN);
        Assert.Equal(1, (int)Accessibility.CLOSED);
    }

    private async Task<Event> AddEvent(Accessibility audience, bool published = true)
    {
        var e = new Event(Category.SPORT, audience, "Test event", RegistrationUrl, published)
        {
            Start = DateTime.Now.AddDays(10), End = DateTime.Now.AddDays(11)
        };
        db.Events.Add(e);
        await db.SaveChangesAsync();
        return e;
    }

    private static EventRequest.PostEvent Draft(string audience) => new()
    {
        Name = "Draft", Category = "SPORT", Accessibility = audience, Url = RegistrationUrl,
        Location = null, Start = null, End = null, Description = null, ICal = null,
        BannerUrl = null, SponsorIds = null, EntryFee = null, Published = false
    };

    public async Task DisposeAsync()
    {
        await db.DisposeAsync();
        await connection.DisposeAsync();
    }

    private sealed class Session : ISessionContextProvider
    {
        public ClaimsPrincipal? User { get; set; }
    }
}
