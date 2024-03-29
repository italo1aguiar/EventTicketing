namespace EventTicketing.Domain.Entities;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    
    // Relationship: One Location to Many Events
    public ICollection<Event> Events { get; set; }
}