using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class GetPubEvents(IEventService eventService) : Endpoint<QueryRequest.SkipTake, Result<EventResponse.GetEvents>>
{
    public override void Configure()
    {
        Get("/api/events/pub");
        AllowAnonymous();
    }

    public override Task<Result<EventResponse.GetEvents>> ExecuteAsync(QueryRequest.SkipTake req, CancellationToken ct)
    {
        return eventService.GetPublishedEvents(req, ct);
    }
}