using EventTicketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventTicketingApi.Infrastructure;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
}