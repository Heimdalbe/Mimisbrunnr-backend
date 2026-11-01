using System.Text;
using Mimisbrunnr.Services.Events;
using Mimisbrunnr.Shared.Events;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class GetEventCalendar(IEventService eventService) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/events/pub/{id:int}/calendar");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        var result = await eventService.GetPublishedEvent(id, ct);
        if (!result.IsSuccess)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        var calendar = EventCalendar.Create(result.Value);
        if (!calendar.IsSuccess)
        {
            foreach (var error in calendar.ValidationErrors)
                AddError(error.ErrorMessage);
            await Send.ErrorsAsync(400, ct);
            return;
        }

        await Send.BytesAsync(Encoding.UTF8.GetBytes(calendar.Value), fileName: $"heimdal-event-{id}.ics",
            contentType: "text/calendar; charset=utf-8", cancellation: ct);
    }
}
