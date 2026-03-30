using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class PostEvent(IEventService eventService) : Endpoint<EventRequest.PostEvent, Result<EventResponse.PostEvent>>
{
    public override void Configure()
    {
        Post("/api/events");
        Roles(AppRoles.EventEditor, AppRoles.Hmdl);
    }

    public override Task<Result<EventResponse.PostEvent>> ExecuteAsync(EventRequest.PostEvent req, CancellationToken ct)
    {
        return eventService.PostEvent(req, ct);
    }
}