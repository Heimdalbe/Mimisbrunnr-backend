using Mimisbrunnr.Shared.Events.Dtos;

namespace Mimisbrunnr.Shared.Events;

public partial class EventResponse
{
    public class GetEvents
    {
        public required IReadOnlyList<EventDto.Simple> Events { get; set; }
    }
}