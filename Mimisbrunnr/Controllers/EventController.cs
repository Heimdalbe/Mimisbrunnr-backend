using Microsoft.AspNetCore.Mvc;
using Mimisbrunnr.Contracts.DTO;
using Mimisbrunnr.Services.Interfaces;

namespace Mimisbrunnr.Controllers
{
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
        public Task<Guid> Post([FromBody] CreateUpdateEventRequest request) {
            return _service.CreateUpdateEvent(request);
        }
    }
}
