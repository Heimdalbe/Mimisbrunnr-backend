using Mimisbrunnr.Contracts.DTO;
using Mimisbrunnr.Models;

namespace Mimisbrunnr.Services.Interfaces
{
    public interface IEventService
    {
        public Task<Guid> CreateUpdateEvent(CreateUpdateEventRequest request);
    }
}
