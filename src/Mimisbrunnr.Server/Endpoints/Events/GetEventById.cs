using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Events.Dtos;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class GetEventById(IEventService eventService) : EndpointWithoutRequest<Result<EventDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/events/{id:int}");
        Roles(AppRoles.EventEditor, AppRoles.Hmdl);
    }

    public override Task<Result<EventDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        
        return eventService.GetEvent(id, ct);
    }
}