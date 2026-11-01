using System.Text;
using Ardalis.Result;
using Mimisbrunnr.Services.Events;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Events.Dtos;
using Xunit;

namespace Mimisbrunnr.Tests;

public class EventCalendarTests
{
    [Theory]
    [InlineData("2026-01-15T19:05:00", "20260115T180500Z", "20260115T193000Z")]
    [InlineData("2026-07-15T19:05:00", "20260715T170500Z", "20260715T183000Z")]
    [InlineData("2026-03-29T01:30:00", "20260329T003000Z", "20260329T010000Z")]
    [InlineData("2026-10-25T01:30:00", "20261024T233000Z", "20261025T020000Z")]
    public void UsesBelgianTimeAcrossSeasonsAndClockChanges(string start, string utcStart, string utcEnd)
    {
        var e = Event();
        e.Start = DateTime.Parse(start);
        e.End = e.Start.Value.AddMinutes(85);
        if (e.Start.Value.Month is 3 or 10)
            e.End = e.Start.Value.Date.AddHours(3);

        var result = EventCalendar.Create(e);

        Assert.True(result.IsSuccess);
        Assert.Contains($"DTSTART:{utcStart}\r\n", result.Value);
        Assert.Contains($"DTEND:{utcEnd}\r\n", result.Value);
    }

    [Fact]
    public void EscapesTextFoldsUtf8AndKeepsPrivateLinksOut()
    {
        var e = Event();
        e.Name = "Feest, café; \\ Heimdal";
        e.Description = string.Concat(Enumerable.Repeat("é🎉", 50)) + "\r\nEND:VEVENT\rBEGIN:VEVENT";
        e.Location = "Gent, België";
        var calendar = EventCalendar.Create(e).Value;
        var unfolded = calendar.Replace("\r\n ", "");

        Assert.All(calendar.Split("\r\n"), line => Assert.True(Encoding.UTF8.GetByteCount(line) <= 75));
        Assert.Equal(calendar, Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(calendar)));
        Assert.Contains("SUMMARY:Feest\\, café\\; \\\\ Heimdal\r\n", unfolded);
        Assert.Contains("LOCATION:Gent\\, België\r\n", unfolded);
        Assert.Contains("\\nEND:VEVENT\\nBEGIN:VEVENT\r\n", unfolded);
        Assert.Single(unfolded.Split("\r\n"), line => line == "BEGIN:VEVENT");
        Assert.DoesNotContain(e.Url!, calendar);
        Assert.DoesNotContain(e.ICal!, calendar);
        Assert.EndsWith("END:VCALENDAR\r\n", calendar);
        Assert.DoesNotContain('\n', calendar.Replace("\r\n", ""));
    }

    [Fact]
    public void KeepsUidWhenEventChangesAndExportsCurrentDetails()
    {
        var e = Event();
        var original = EventCalendar.Create(e).Value;
        e.Name = "Verplaatst feest";
        e.Start = e.Start!.Value.AddDays(1);
        e.End = e.End!.Value.AddDays(1);
        var updated = EventCalendar.Create(e).Value;

        Assert.Contains("UID:heimdal-event-42@heimdal.be\r\n", original);
        Assert.Contains("UID:heimdal-event-42@heimdal.be\r\n", updated);
        Assert.Contains("SUMMARY:Verplaatst feest\r\n", updated);
        Assert.Contains("DTSTART:20261105T180500Z\r\n", updated);
    }

    [Theory]
    [InlineData(null, "2026-11-04T20:30:00")]
    [InlineData("2026-11-04T19:05:00", null)]
    [InlineData("2026-11-04T19:05:00", "2026-11-04T19:05:00")]
    [InlineData("2026-11-04T19:05:00", "2026-11-04T18:05:00")]
    [InlineData("2026-03-29T02:30:00", "2026-03-29T03:30:00")]
    [InlineData("2026-03-29T01:30:00", "2026-03-29T02:30:00")]
    public void RejectsMissingReversedOrNonexistentTimes(string? start, string? end)
    {
        var e = Event();
        e.Start = start is null ? null : DateTime.Parse(start);
        e.End = end is null ? null : DateTime.Parse(end);

        Assert.Equal(ResultStatus.Invalid, EventCalendar.Create(e).Status);
    }

    [Fact]
    public void PublishedEventDoesNotRequireManualCalendarUrl()
    {
        var request = new EventRequest.PostEvent
        {
            Name = "Feest", Category = "SPORT", Accessibility = "OPEN", Location = "Gent",
            Start = new DateTime(2026, 11, 4, 19, 5, 0), End = new DateTime(2026, 11, 4, 20, 30, 0),
            Description = "Test", BannerUrl = "https://example.test/banner.png", SponsorIds = [],
            EntryFee = "Gratis", Url = null, Published = true
        };

        Assert.True(new EventRequest.PostEvent.Validator().Validate(request).IsValid);
    }

    private static EventDto.Detailed Event() => new()
    {
        Id = 42, Name = "Feest", Category = "SPORT", Accessibility = "OPEN", AllowedRoles = [],
        Start = new DateTime(2026, 11, 4, 19, 5, 0), End = new DateTime(2026, 11, 4, 20, 30, 0),
        Location = "Gent", Description = "Test", ICal = "https://example.test/old-calendar",
        Banner = null, Sponsors = [], EntryFee = "Gratis", Published = true,
        Url = "https://example.test/private-registration-link"
    };
}
