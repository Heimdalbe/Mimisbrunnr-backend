using Mimisbrunnr.Contracts.Responses;
using Mimisbrunnr.Models;
using Riok.Mapperly.Abstractions;

namespace Mimisbrunnr.Mappers
{
    [Mapper]
    public partial class EventDetailItemMapper
    {
        [MapProperty(nameof(Event.Owner.Guid), nameof(EventDetailItem.OwnerGuid))]
        [MapProperty(nameof(Event.Owner.Name), nameof(EventDetailItem.OwnerName))]
        public partial EventDetailItem EventToEventDetailItem(Event @event);
    }
}
