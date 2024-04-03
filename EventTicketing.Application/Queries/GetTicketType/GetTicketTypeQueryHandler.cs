using AutoMapper;
using EventTicketing.Application.Dtos;
using EventTicketing.Application.Queries.GetEvent;
using EventTicketing.Application.Repositories;
using EventTicketing.Domain.Entities;
using MediatR;

namespace EventTicketing.Application.Queries.GetTicketType;

public class GetTicketTypeQueryHandler : IRequestHandler<GetTicketTypeQuery,TicketTypeDto>
{
    private readonly IRepository<TicketType> _ticketTypeRepository;
    private readonly IMapper _mapper;
    
    public GetTicketTypeQueryHandler(IRepository<TicketType> ticketTypeRepository, IMapper mapper)
    {
        _ticketTypeRepository = ticketTypeRepository;
        _mapper = mapper;
    }
    public async Task<TicketTypeDto> Handle(GetTicketTypeQuery request, CancellationToken cancellationToken)
    {
        var ticketTypeResult = await _ticketTypeRepository.GetByIdWithDetailsAsync(request.EventId);
        if (ticketTypeResult == null)
            throw new KeyNotFoundException("The item was no found.");
        return _mapper.Map<TicketTypeDto>(ticketTypeResult);
    }
}