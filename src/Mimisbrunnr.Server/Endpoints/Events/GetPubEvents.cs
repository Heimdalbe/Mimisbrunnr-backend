using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class GetPubEvents(IEventService eventService, ISessionContextProvider sessionContextProvider) : Endpoint<QueryRequest.SkipTake, Result<EventResponse.GetEvents>>
{
    public override void Configure()
    {
        Get("/api/events/pub");
    }

    public override Task<Result<EventResponse.GetEvents>> ExecuteAsync(QueryRequest.SkipTake req, CancellationToken ct)
    {
        var user = sessionContextProvider.User;
        if (user is not null && (user.IsInRole(AppRoles.Schacht) || user.IsInRole(AppRoles.Commilitones))){
                return eventService.GetPublishedEvents(req, ct);
        }
        return eventService.GetOpenEvents(req, ct);
    }
}