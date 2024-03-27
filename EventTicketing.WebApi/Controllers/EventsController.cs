using EventTicketing.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventTicketing.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _eventRepository;

    public EventsController(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var events = _eventRepository.GetAllEvents();
        return Ok(events);
    }
}       