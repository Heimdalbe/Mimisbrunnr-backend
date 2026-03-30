using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class PutEvent(IEventService eventService) : Endpoint<EventRequest.PutEvent, Result<EventResponse.PutEvent>>
{
    public override void Configure()
    {
        Put("/api/events/{id:int}");
        Roles(AppRoles.EventEditor, AppRoles.Hmdl);
    }

    public override Task<Result<EventResponse.PutEvent>> ExecuteAsync(EventRequest.PutEvent req, CancellationToken ct)
    {
        int id = Route<int>("id");
        return eventService.PutEvent(id, req, ct);
    }
}