using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Mimmisbrunnr.Api.DTOs.Activities;
using Mimmisbrunnr.Domain.Activities;
using Mimmisbrunnr.Infrastructure.Context;
using Mimmisbrunnr.Infrastructure.Services;
using Mimmisbrunnr.Infrastructure.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mimmisbrunnr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _service;

        public ActivityController(IActivityService service)
        {
            _service = Guard.Against.Null(service, nameof(service));
        }

        // GET: api/<EventController>
        [HttpGet]
        public async Task<IEnumerable<Activity>> GetAllEvents()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<ActivityOverviewDTO>> GetOverview(int amount)
        {
            var activities = await _service.GetOverviewAsync(amount);

            return activities.Select(activity => new ActivityOverviewDTO()
            {
                Id = activity.Id,
                Name = activity.Name,
                Start = activity.Start,
                End = activity.End,
                Category = activity.Category,
                Banner = new DTOs.Common.ImageDTO
                {
                    Url = activity.Banner.Url,
                    Description = activity.Banner.Description,
                }
            }).ToList();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Activity newEvent)
        {
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id);
                return Ok(deleted);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }
    }
}
