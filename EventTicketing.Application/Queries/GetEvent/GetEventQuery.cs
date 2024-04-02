using EventTicketing.Application.Dtos;
using EventTicketing.Domain.Entities;
using MediatR;

namespace EventTicketing.Application.Queries.GetEvent;

public class GetEventQuery : IRequest<EventDto>
{
    public GetEventQuery(int eventId)
    {
        EventId = eventId;
    }

    public int EventId { get; set; }
}