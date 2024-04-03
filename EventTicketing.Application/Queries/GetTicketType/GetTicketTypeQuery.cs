using EventTicketing.Application.Dtos;
using MediatR;

namespace EventTicketing.Application.Queries.GetTicketType;

public class GetTicketTypeQuery : IRequest<TicketTypeDto>
{
    public GetTicketTypeQuery(int eventId)
    {
        EventId = eventId;
    }

    public int EventId { get; set; }
}