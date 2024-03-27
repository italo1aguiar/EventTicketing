using EventTicketing.Domain.Entities;

namespace EventTicketing.Application.Repositories;

public interface IEventRepository
{
    IEnumerable<Event> GetAllEvents();
}