using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class GetEvents(IEventService eventService) : EndpointWithoutRequest<Result<EventResponse.GetEvents>>
{
    public override void Configure()
    {
        Get("/api/events/");
        Roles(AppRoles.EventEditor, AppRoles.Hmdl);
    }

    public override Task<Result<EventResponse.GetEvents>> ExecuteAsync(CancellationToken ct)
    {
        return eventService.GetEvents(ct);
    }
}