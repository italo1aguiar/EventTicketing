namespace EventTicketing.Domain.Entities;

public class Organizer
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Add more properties as needed, such as contact information, description, etc.

    // Relationship: One Organizer to Many Events
    public ICollection<Event> Events { get; set; }
}