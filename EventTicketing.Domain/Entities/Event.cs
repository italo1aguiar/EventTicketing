namespace EventTicketing.Domain.Entities;

public class Event
{
    public Event(string name, string description, DateTime date, int locationId, int organizerId, int eventCategoryId)
    {
        Name = name;
        Description = description;
        Date = date;
        LocationId = locationId;
        OrganizerId = organizerId;
        EventCategoryId = eventCategoryId;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Location Location { get; set; }
    public int LocationId { get; set; }
    public Organizer Organizer { get; set; }
    public int OrganizerId { get; set; }
    
    public int EventCategoryId { get; set; }
    
    public EventCategory EventCategory { get; set; }

// Relationship: One Event to Many TicketTypes
    public ICollection<TicketType> TicketTypes { get; set; }
}