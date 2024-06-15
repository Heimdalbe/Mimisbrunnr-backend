using Mimisbrunnr.Contracts.Requests;
using Mimisbrunnr.Contracts.Responses;
using Mimisbrunnr.Models;

namespace Mimisbrunnr.Services.Interfaces
{
    public interface IEventService
    {
        public Task<Guid> CreateUpdateEvent(CreateUpdateEventRequest request);
        public Task<List<EventListItem>> GetAll();
        public Task<EventDetailItem> Get(Guid guid);
    }
}
