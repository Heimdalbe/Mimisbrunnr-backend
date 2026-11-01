using System.Globalization;
using System.Text;
using Mimisbrunnr.Shared.Events.Dtos;

namespace Mimisbrunnr.Services.Events;

public static class EventCalendar
{
    private static readonly TimeZoneInfo Brussels = TimeZoneInfo.FindSystemTimeZoneById("Europe/Brussels");

    public static Result<string> Create(EventDto.Detailed e)
    {
        if (e.Start is null || e.End is null)
            return Result.Invalid(new ValidationError("Start", "Het evenement heeft geen volledige begin- en eindtijd."));

        var start = DateTime.SpecifyKind(e.Start.Value, DateTimeKind.Unspecified);
        var end = DateTime.SpecifyKind(e.End.Value, DateTimeKind.Unspecified);
        if (end <= start || Brussels.IsInvalidTime(start) || Brussels.IsInvalidTime(end))
            return Result.Invalid(new ValidationError("End", "Het evenement heeft geen geldige begin- en eindtijd."));

        string[] lines =
        [
            "BEGIN:VCALENDAR",
            "VERSION:2.0",
            "PRODID:-//Heimdal//Mimisbrunnr//NL",
            "CALSCALE:GREGORIAN",
            "BEGIN:VEVENT",
            $"UID:heimdal-event-{e.Id}@heimdal.be",
            $"DTSTAMP:{DateTime.UtcNow.ToString("yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture)}",
            $"DTSTART:{Utc(start)}",
            $"DTEND:{Utc(end)}",
            $"SUMMARY:{Escape(e.Name)}",
            $"DESCRIPTION:{Escape(e.Description)}",
            $"LOCATION:{Escape(e.Location)}",
            $"URL:https://heimdal.be/evenementen/{e.Id}",
            "END:VEVENT",
            "END:VCALENDAR"
        ];

        var calendar = new StringBuilder();
        foreach (var line in lines)
        {
            var octets = 0;
            foreach (var rune in line.EnumerateRunes())
            {
                if (octets + rune.Utf8SequenceLength > 75)
                {
                    calendar.Append("\r\n ");
                    octets = 1;
                }
                calendar.Append(rune.ToString());
                octets += rune.Utf8SequenceLength;
            }
            calendar.Append("\r\n");
        }
        return Result.Success(calendar.ToString());
    }

    private static string Utc(DateTime date) => TimeZoneInfo.ConvertTimeToUtc(date, Brussels)
        .ToString("yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture);

    private static string Escape(string? text) => (text ?? "")
        .Replace("\\", "\\\\").Replace("\r\n", "\n").Replace('\r', '\n')
        .Replace("\n", "\\n").Replace(";", "\\;").Replace(",", "\\,");
}
