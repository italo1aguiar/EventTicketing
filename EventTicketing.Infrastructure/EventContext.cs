using EventTicketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventTicketingApi.Infrastructure;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketType> TicketTypes { get; set; }
    public DbSet<TicketPricePeriod> TicketPricePeriods { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Event and Location (One-to-Many)
    modelBuilder.Entity<Location>()
        .HasMany(l => l.Events)
        .WithOne(e => e.Location) // Assuming Event has a Location navigation property
        .HasForeignKey(e => e.LocationId); // Assuming Event has a LocationId foreign key

    // Event and Organizer (Many-to-One)
    modelBuilder.Entity<Event>()
        .HasOne(e => e.Organizer) // Assuming Event has an Organizer navigation property
        .WithMany(o => o.Events)  // Assuming Organizer has an Events collection
        .HasForeignKey(e => e.OrganizerId); // Assuming Event has an OrganizerId foreign key

    // Event and EventCategory (Many-to-Many)
    // This typically requires a join table (e.g., EventCategoryMap)
    // Assuming there's a join entity for EventCategory and Event

    // Order and User (Many-to-One)
    modelBuilder.Entity<Order>()
        .HasOne(o => o.User)  // Assuming Order has a User navigation property
        .WithMany(u => u.Orders)  // Assuming User has an Orders collection
        .HasForeignKey(o => o.UserId); // Assuming Order has a UserId foreign key

    // Order and Payment (One-to-One)
    modelBuilder.Entity<Order>()
        .HasOne(o => o.Payment) // Assuming Order has a Payment navigation property
        .WithOne(p => p.Order) // Assuming Payment has an Order navigation property
        .HasForeignKey<Payment>(p => p.OrderId); // Assuming Payment has an OrderId foreign key

    // Ticket and TicketType (Many-to-One)
    modelBuilder.Entity<Ticket>()
        .HasOne(t => t.TicketType) // Assuming Ticket has a TicketType navigation property
        .WithMany(tt => tt.Tickets) // Assuming TicketType has a Tickets collection
        .HasForeignKey(t => t.TicketTypeId); // Assuming Ticket has a TicketTypeId foreign key

    // TicketType and TicketPricePeriod (One-to-Many)
    modelBuilder.Entity<TicketType>()
        .HasMany(tt => tt.TicketPricePeriods) // Assuming TicketType has TicketPricePeriods collection
        .WithOne(tpp => tpp.TicketType) // Assuming TicketPricePeriod has a TicketType navigation property
        .HasForeignKey(tpp => tpp.TicketTypeId); // Assuming TicketPricePeriod has a TicketTypeId foreign key

    // Additional configurations as needed
}

    
}