using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Events.Dtos;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class GetPubEventById(IEventService eventService, ISessionContextProvider sessionContextProvider) : EndpointWithoutRequest<Result<EventDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/events/pub/{id:int}");
    }

    public override Task<Result<EventDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        var user = sessionContextProvider.User;
        
        if (user is not null && (user.IsInRole(AppRoles.Schacht) || user.IsInRole(AppRoles.Commilitones))){
            return eventService.GetPublishedEvent(id, ct);
        }
        return eventService.GetOpenEvent(id, ct);
    }
}