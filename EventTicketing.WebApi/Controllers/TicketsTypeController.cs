using EventTicketing.Application.Commands.CreateTicket;
using EventTicketing.Application.Queries.GetTicketType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventTicketing.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketsTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicket(int id)
    {
        try
        {
            var query = new GetTicketTypeQuery(id);
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
    public async Task<IActionResult> CreateTicket(CreateTicketTypeCommand typeCommand)
    {
        try
        {
            await _mediator.Send(typeCommand);
            return Ok("Tickets created successfully.");
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