using AutoMapper;
using EventTicketing.Application.Dtos;
using EventTicketing.Application.Repositories;
using EventTicketing.Domain.Entities;
using MediatR;

namespace EventTicketing.Application.Queries.GetEvent;

public class GetEventQueryHandler : IRequestHandler<GetEventQuery,EventDto>
{
    private readonly IRepository<Event> _eventRepository;
    private readonly IMapper _mapper;
    
    public GetEventQueryHandler(IRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    public async Task<EventDto> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var eventResult = await _eventRepository.GetByIdWithDetailsAsync(request.EventId);
        if (eventResult == null)
            throw new KeyNotFoundException("The item was no found.");
        return _mapper.Map<EventDto>(eventResult);
    }
}