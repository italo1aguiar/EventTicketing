using EventTicketing.Application.Repositories;
using EventTicketing.Domain.Entities;
using MediatR;

namespace EventTicketing.Application.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
{
    private readonly IRepository<Event> _eventRepository;
    private readonly IRepository<Organizer> _organizerRepository;
    private readonly IRepository<Location> _locationRepository;
    private readonly IRepository<EventCategory> _eventCategoryRepository;

    public CreateEventCommandHandler(
        IRepository<Event> eventRepository,
        IRepository<Organizer> organizerRepository,
        IRepository<Location> locationRepository,
        IRepository<EventCategory> eventCategoryRepository
    )
    {
        _eventRepository = eventRepository;
        _organizerRepository = organizerRepository;
        _locationRepository = locationRepository;
        _eventCategoryRepository = eventCategoryRepository;
    }

    public async Task Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        var organizer = await _organizerRepository.GetByIdAsync(command.OrganizerId);
        var location = await _locationRepository.GetByIdAsync(command.LocationId);
        var category = await _eventCategoryRepository.GetByIdAsync(command.CategoryId);

        if (organizer == null || location == null || category == null)
        {
            throw new KeyNotFoundException("A required related entity was not found.");
        }

        // Create the Event entity
        var eventEntity = new Event
        (
            command.Name,
            command.Description,
            command.Date,
            command.OrganizerId,
            command.LocationId,
            command.CategoryId
        );

        // Save the new event
        await _eventRepository.AddAsync(eventEntity);
        await _eventRepository.SaveChangesAsync(cancellationToken);
    }
}