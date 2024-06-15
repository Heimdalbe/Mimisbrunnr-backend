using Microsoft.AspNetCore.Mvc;
using Mimisbrunnr.Contracts.Requests;
using Mimisbrunnr.Contracts.Responses;
using Mimisbrunnr.Services.Interfaces;

namespace Mimisbrunnr.Controllers
{
    /// <summary>
    /// REST controller for Events
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new Event if no Guid is provided and tries to update it if one is provided. Optionally schedules a job to post to Discord based on settings.
        /// </summary>
        /// <param name="request">New Event data</param>
        /// <returns>Guid of the Event</returns>
        [HttpPost]
        [Route("Post")]
        public Task<Guid> Post([FromBody] CreateUpdateEventRequest request)
        {
            return _service.CreateUpdateEvent(request);
        }

        /// <summary>
        /// Returns a list of all Events, past and present. Ordered by StartDate.
        /// </summary>
        /// <returns>List of Events, minimal data for overview</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<EventListItem>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<EventDetailItem> Get([FromQuery] Guid eventGuid)
        {
            return await _service.Get(eventGuid);
        }

        [HttpDelete("{guid:guid}")]
        public async Task Delete(Guid guid)
        {
            await _service.Delete(guid);
        }
    }
}
