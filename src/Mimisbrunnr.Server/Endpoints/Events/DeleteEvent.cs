using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class DeleteEvent(IEventService eventService) : EndpointWithoutRequest<Result<EventResponse.DeleteEvent>>
{
    public override void Configure()
    {
        Delete("/api/events/{id:int}");
        Roles(AppRoles.EventEditor, AppRoles.Hmdl);
    }

    public override Task<Result<EventResponse.DeleteEvent>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return eventService.DeleteEvent(id, ct);
    }
}