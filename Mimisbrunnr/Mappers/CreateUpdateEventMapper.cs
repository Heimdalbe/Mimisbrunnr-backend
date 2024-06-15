using Mimisbrunnr.Contracts.Requests;
using Mimisbrunnr.Models;
using Riok.Mapperly.Abstractions;

namespace Mimisbrunnr.Mappers
{
    [Mapper]
    public partial class CreateUpdateEventMapper
    {
        [MapProperty(nameof(@CreateUpdateEventRequest.PostToDiscordSettings.DiscordDescription), nameof(@Event.DiscordDescription))]
        public partial Event CreateUpdateEventRequestToEvent(CreateUpdateEventRequest request);
    }
}
