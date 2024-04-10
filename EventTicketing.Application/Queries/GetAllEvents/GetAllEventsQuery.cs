using EventTicketing.Application.Dtos;
using MediatR;

namespace EventTicketing.Application.Queries.GetAllEvents;

public class GetAllEventsQuery : IRequest<IEnumerable<EventDto>>
{
    
}