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

    [Theory]
    [InlineData("", null, true)]
    [InlineData("", "Schacht", true)]
    [InlineData("Heimie", null, false)]
    [InlineData("Heimie", "Feut", false)]
    [InlineData("Heimie", "Heimie", true)]
    [InlineData("Heimie", "Schacht", false)]
    [InlineData("Heimie", "Commilitones", false)]
    [InlineData("Heimie", "Heimie,Schacht", true)]
    [InlineData("Heimie", "Heimie,Commilitones", true)]
    [InlineData("Schacht", null, false)]
    [InlineData("Schacht", "Heimie", false)]
    [InlineData("Schacht", "Schacht", false)]
    [InlineData("Schacht", "Heimie,Schacht", true)]
    [InlineData("Schacht", "Heimie,Commilitones", false)]
    [InlineData("Commilitones", "Commilitones", false)]
    [InlineData("Commilitones", "Heimie", false)]
    [InlineData("Commilitones", "Heimie,Commilitones", true)]
    [InlineData("Commilitones", "Heimie,Schacht", false)]
    [InlineData("Schacht,Commilitones", "Schacht,Commilitones", false)]
    [InlineData("Schacht,Commilitones", "Heimie,Schacht", true)]
    [InlineData("Schacht,Commilitones", "Heimie,Commilitones", true)]
    [InlineData("Schacht,Commilitones", "Heimie", false)]
    [InlineData("Heimie,Schacht", "Heimie", true)]
    [InlineData("Heimie,Schacht", "Schacht", false)]
    [InlineData("Feut", "Feut", true)]
    [InlineData("Feut", null, false)]
    [InlineData("Feut", "Heimie", false)]
    [InlineData("Feut,Schacht", "Feut", true)]
    [InlineData("Schacht", "Hmdl", true)]
    [InlineData("Schacht", "EventEditor", false)]
    public async Task SelectedRolesAndPaidMembershipProtectEveryPublicResponse(string selection, string? accountRoles, bool allowed)
    {
        SignIn(accountRoles);
        var e = await AddEvent(Accessibility.CLOSED, Split(selection));
        var detail = await events.GetPublishedEvent(e.Id, default);
        var list = await events.GetPublishedEvents(new QueryRequest.SkipTake { Take = 100 }, default);
        var item = Assert.Single(list.Value.Events);
        Assert.Equal(ResultStatus.Ok, detail.Status);
        Assert.Equal(allowed ? RegistrationUrl : null, detail.Value.Url);
        Assert.Equal(allowed ? RegistrationUrl : null, item.Url);
        Assert.Equal(Split(selection), detail.Value.AllowedRoles);
        if (allowed)
            Assert.Null(detail.Value.RegistrationAccessError);
        else
        {
            Assert.False(string.IsNullOrWhiteSpace(detail.Value.RegistrationAccessError));
            if (accountRoles is null) Assert.Contains("Log in", detail.Value.RegistrationAccessError);
        }
        Assert.Equal(RegistrationUrl, e.Url);
        Assert.Equal(RegistrationUrl, (await events.GetEvent(e.Id, default)).Value.Url);
        Assert.Equal(allowed ? RegistrationUrl : null, (await events.GetOpenEvent(e.Id, default)).Value.Url);
        await db.SaveChangesAsync();
        db.ChangeTracker.Clear();
        Assert.Equal(RegistrationUrl, (await db.Events.FindAsync(e.Id))!.Url);
    }

    [Theory]
    [InlineData(Accessibility.OPEN, null, true)]
    [InlineData(Accessibility.HEIMIES, "Schacht", false)]
    [InlineData(Accessibility.HEIMIES, "Heimie", true)]
    [InlineData(Accessibility.CLOSED, "Schacht", false)]
    [InlineData(Accessibility.CLOSED, "Commilitones", false)]
    [InlineData(Accessibility.CLOSED, "Heimie,Schacht", true)]
    [InlineData(Accessibility.CLOSED, "Heimie,Commilitones", true)]
    public async Task LegacyEventsKeepTheirSelectionButRequireExplicitPaidMembership(Accessibility audience, string? roles, bool allowed)
    {
        SignIn(roles);
        var e = await AddEvent(audience);
        var response = await events.GetPublishedEvent(e.Id, default);
        Assert.Equal(allowed ? RegistrationUrl : null, response.Value.Url);
    }

    [Fact]
    public async Task MissingMembershipExplainsWhyStatusAloneIsInsufficient()
    {
        SignIn("Schacht");
        var e = await AddEvent(Accessibility.CLOSED, [AppRoles.Schacht]);
        Assert.Contains("betaald lidmaatschap", (await events.GetPublishedEvent(e.Id, default)).Value.RegistrationAccessError);
    }

    [Fact]
    public async Task UnauthenticatedRoleClaimsDoNotGrantAccess()
    {
        session.User = new ClaimsPrincipal(new ClaimsIdentity([new Claim(ClaimTypes.Role, AppRoles.Hmdl)]));
        var e = await AddEvent(Accessibility.CLOSED);
        Assert.Null((await events.GetPublishedEvent(e.Id, default)).Value.Url);
    }

    [Fact]
    public async Task OpenListCannotLeakARestrictedLinkEvenWithInconsistentLegacyAccessibility()
    {
        await AddEvent(Accessibility.OPEN, [AppRoles.Schacht]);
        Assert.Null(Assert.Single((await events.GetOpenEvents(new() { Take = 100 }, default)).Value.Events).Url);
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
    [InlineData("Hmdl")]
    [InlineData("EventEditor")]
    [InlineData("UNKNOWN")]
    [InlineData("")]
    [InlineData(null)]
    public async Task InvalidRoleSelectionCannotChangeAnEvent(string? role)
    {
        var e = await AddEvent(Accessibility.CLOSED, [AppRoles.Heimie]);
        var result = await events.PutEvent(e.Id, new() { Name = "changed", AllowedRoles = [role!] }, default);
        Assert.Equal(ResultStatus.Invalid, result.Status);
        Assert.Equal("AllowedRoles", Assert.Single(result.ValidationErrors).Identifier);
        Assert.Equal("Test event", e.Name);
        Assert.Equal(new[] { AppRoles.Heimie }, e.AllowedRoles);
        var request = Draft();
        request.AllowedRoles = [role!];
        Assert.Equal(ResultStatus.Invalid, (await events.PostEvent(request, default)).Status);
        Assert.Equal(1, await db.Events.CountAsync());
    }

    [Theory]
    [InlineData("999")]
    [InlineData("UNKNOWN")]
    public async Task InvalidLegacyAudienceCannotBeSaved(string audience)
    {
        var e = await AddEvent(Accessibility.OPEN);
        Assert.Equal(ResultStatus.Invalid, (await events.PutEvent(e.Id, new() { Accessibility = audience }, default)).Status);
        var request = Draft();
        request.Accessibility = audience;
        Assert.Equal(ResultStatus.Invalid, (await events.PostEvent(request, default)).Status);
    }

    [Fact]
    public async Task CustomSelectionSurvivesCreationReloadEditingAndUnrelatedUpdates()
    {
        var request = Draft();
        request.AllowedRoles = ["schacht", "SCHACHT", AppRoles.Commilitones];
        var created = await events.PostEvent(request, default);
        Assert.Equal(ResultStatus.Ok, created.Status);
        db.ChangeTracker.Clear();
        var e = (await db.Events.FindAsync(created.Value.Id))!;
        Assert.Equal(new[] { AppRoles.Schacht, AppRoles.Commilitones }, e.AllowedRoles);
        Assert.Equal(Accessibility.CLOSED, e.Accessibility);
        Assert.Equal(ResultStatus.Ok, (await events.PutEvent(e.Id, new() { Name = "Changed" }, default)).Status);
        db.ChangeTracker.Clear();
        Assert.Equal(new[] { AppRoles.Schacht, AppRoles.Commilitones }, (await events.GetEvent(e.Id, default)).Value.AllowedRoles);
        Assert.Equal(ResultStatus.Ok, (await events.PutEvent(e.Id, new() { AllowedRoles = [AppRoles.Heimie] }, default)).Status);
        db.ChangeTracker.Clear();
        Assert.Equal(new[] { AppRoles.Heimie }, (await events.GetEvent(e.Id, default)).Value.AllowedRoles);
    }

    [Fact]
    public async Task ClearingSelectionExplicitlyMakesEventPublic()
    {
        var e = await AddEvent(Accessibility.CLOSED, [AppRoles.Schacht]);
        Assert.Equal(ResultStatus.Ok, (await events.PutEvent(e.Id, new() { AllowedRoles = [] }, default)).Status);
        db.ChangeTracker.Clear();
        var result = await events.GetPublishedEvent(e.Id, default);
        Assert.Empty(result.Value.AllowedRoles);
        Assert.Equal("OPEN", result.Value.Accessibility);
        Assert.Equal(RegistrationUrl, result.Value.Url);
    }

    [Fact]
    public void ExistingStoredAudienceValuesKeepTheirMeaning()
    {
        Assert.Equal(0, (int)Accessibility.OPEN);
        Assert.Equal(1, (int)Accessibility.CLOSED);
    }

    private static List<string> Split(string value) => value.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

    private void SignIn(string? roles) => session.User = roles is null ? null : new ClaimsPrincipal(new ClaimsIdentity(
        Split(roles).Select(role => new Claim(ClaimTypes.Role, role)), "test"));

    private async Task<Event> AddEvent(Accessibility audience, List<string>? roles = null, bool published = true)
    {
        var e = new Event(Category.SPORT, audience, "Test event", RegistrationUrl, published)
        {
            AllowedRoles = roles, Start = DateTime.Now.AddDays(10), End = DateTime.Now.AddDays(11)
        };
        db.Events.Add(e);
        await db.SaveChangesAsync();
        return e;
    }

    private static EventRequest.PostEvent Draft() => new()
    {
        Name = "Draft", Category = "SPORT", Accessibility = "OPEN", Url = RegistrationUrl,
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
