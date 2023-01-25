using calendar.Models;
using calendar.Services.EventService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            return Ok(_eventService.GetAllEvents());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(string id)
        {
            var ev=_eventService.GetEventById(id);
            if(ev == null)
            {
                return NotFound("Event not found");
            }
            return Ok(ev);
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event ev)
        {
            var addedEvent = _eventService.AddEvent(ev);
            if (ev == null)
            {
                return StatusCode(500);
            }
            return Ok(ev);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(string id,Event ev)
        {
            var updatedEvent = _eventService.UpdateEvent(id,ev);
            if (ev == null)
            {
                return NotFound("Event not found");
            }
            return Ok(ev);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            var deletedEvent = _eventService.DeleteEvent(id);
            if (deletedEvent == false)
            {
                return NotFound("Event not found");
            }
            return Ok(deletedEvent);
        }
    }
}
