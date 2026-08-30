using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Events.Dtos;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Events;

public class GetPubEventById(IEventService eventService) : EndpointWithoutRequest<Result<EventDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/events/pub/{id:int}");
        AllowAnonymous();
    }

    public override Task<Result<EventDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        
        return eventService.GetPublishedEvent(id,ct);
    }
}