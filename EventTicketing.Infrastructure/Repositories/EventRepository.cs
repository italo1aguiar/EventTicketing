using EventTicketing.Application.Repositories;
using EventTicketing.Domain.Entities;

namespace EventTicketingApi.Infrastructure.Repositories;

public class EventRepository: IEventRepository
{
    public IEnumerable<Event> GetAllEvents()
    {
        return new List<Event>
        {
            new Event { Id = 1, Name = "Concert", Description = "Live music concert", Date = DateTime.Now.AddDays(10) },
            new Event { Id = 2, Name = "Art Exhibition", Description = "Modern art exhibition", Date = DateTime.Now.AddDays(30) },
            };
    }
}