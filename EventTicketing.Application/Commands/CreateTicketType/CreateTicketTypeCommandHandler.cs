using EventTicketing.Application.Repositories;
using EventTicketing.Domain.Entities;
using MediatR;

namespace EventTicketing.Application.Commands.CreateTicket;

public class CreateTicketTypeCommandHandler : IRequestHandler<CreateTicketTypeCommand>
{
    private readonly IRepository<TicketType> _ticketTypeRepository;
    private readonly IRepository<Event> _eventRepository;

    public CreateTicketTypeCommandHandler(IRepository<TicketType> ticketTypeRepository, IRepository<Event> eventRepository)
    {
        _ticketTypeRepository = ticketTypeRepository;
        _eventRepository = eventRepository;
    }

    public async Task Handle(CreateTicketTypeCommand command, CancellationToken cancellationToken)
    {
        // Validate if the event exists
        var eventEntity = await _eventRepository.GetByIdAsync(command.EventId);
        if (eventEntity == null)
        {
            throw new KeyNotFoundException($"Event with ID {command.EventId} not found.");
        }

        var ticketType = new TicketType
        {
            EventId = command.EventId,
            Name = command.Name,
            TicketPricePeriods = command.TicketPricePeriods.Select(p => new TicketPricePeriod
            {
                Price = p.Price,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Quantity = p.Quantity
            }).ToList(),
        };

        await _ticketTypeRepository.AddAsync(ticketType);
        await _ticketTypeRepository.SaveChangesAsync(cancellationToken);
    }
}