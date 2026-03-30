using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events.Dtos;

namespace Mimisbrunnr.Shared.Events;

public interface IEventService
{
    Task<Result<EventResponse.GetEvents>> GetOpenEvents(QueryRequest.SkipTake req, CancellationToken ct);
    
    Task<Result<EventResponse.GetEvents>> GetPublishedEvents(QueryRequest.SkipTake req, CancellationToken ct);

    Task<Result<EventResponse.GetEvents>> GetEvents(CancellationToken ct);

    Task<Result<EventDto.Detailed>> GetOpenEvent(int id, CancellationToken ct);

    Task<Result<EventDto.Detailed>> GetPublishedEvent(int id, CancellationToken ct);
    
    Task<Result<EventDto.Detailed>> GetEvent(int id, CancellationToken ct);

    Task<Result<EventResponse.PostEvent>> PostEvent(EventRequest.PostEvent req, CancellationToken ct);

    Task<Result<EventResponse.PutEvent>> PutEvent(int id, EventRequest.PutEvent req, CancellationToken ct);
    
    Task<Result<EventResponse.DeleteEvent>> DeleteEvent(int id, CancellationToken ct);
}