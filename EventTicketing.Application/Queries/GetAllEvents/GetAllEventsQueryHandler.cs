using AutoMapper;
using EventTicketing.Application.Dtos;
using EventTicketing.Application.Repositories;
using EventTicketing.Domain.Entities;
using MediatR;

namespace EventTicketing.Application.Queries.GetAllEvents;

public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery,IEnumerable<EventDto>>
{
    private readonly IRepository<Event> _eventRepository;
    private readonly IMapper _mapper;
    
    public GetAllEventsQueryHandler(IRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        var eventsResult = await _eventRepository.GetAllWithDetailsAsync();
        if (eventsResult == null)
            throw new KeyNotFoundException("The item was no found.");
        return _mapper.Map<IEnumerable<EventDto>>(eventsResult);
    }
}