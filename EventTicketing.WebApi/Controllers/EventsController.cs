using EventTicketing.Application.Commands.CreateEvent;
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

    [HttpPost]
    public async Task<IActionResult> CreateEvent(CreateEventCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}