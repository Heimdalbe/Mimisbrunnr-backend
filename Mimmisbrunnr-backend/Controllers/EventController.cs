using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Mimmisbrunnr.Domain.Event;
using Mimmisbrunnr.Infrastructure.Context;
using Mimmisbrunnr.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mimmisbrunnr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IService _service;

        public EventController(IService service)
        {
            _service = Guard.Against.Null(service, nameof(service));
        }

        // GET: api/<EventController>
        [HttpGet]
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _service.GetAllAsync<Event>();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
