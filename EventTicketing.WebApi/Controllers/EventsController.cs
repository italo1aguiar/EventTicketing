using EventTicketing.Application.Commands.CreateEvent;
using EventTicketing.Application.Queries.GetEvent;
using EventTicketing.Application.Repositories;
using EventTicketing.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventTicketing.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        try
        {
            var query = new GetEventQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred");
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateEvent(CreateEventCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok("Event created successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred");
        }
    }
}