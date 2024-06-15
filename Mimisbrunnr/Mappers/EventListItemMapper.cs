using Mimisbrunnr.Contracts.Requests;
using Mimisbrunnr.Contracts.Responses;
using Mimisbrunnr.Models;
using Riok.Mapperly.Abstractions;

namespace Mimisbrunnr.Mappers
{
    [Mapper]
    public partial class EventListItemMapper
    {
        public partial EventListItem EventToEventListItem(Event @event);
    }
}
