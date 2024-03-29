namespace EventTicketing.Domain.Entities;

public class EventCategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Relationship: One EventCategory to Many Events
    public ICollection<Event> Events { get; set; }
}