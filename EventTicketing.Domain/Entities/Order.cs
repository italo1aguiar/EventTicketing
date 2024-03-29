namespace EventTicketing.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; } // Foreign key to identify the user who made the order
    public DateTime OrderDate { get; set; } // Date and time when the order was placed

    // Relationship: Many Orders to One User
    public User User { get; set; }

    // Relationship: One Order to Many Tickets
    public ICollection<Ticket> Tickets { get; set; }
    
    public Payment Payment { get; set; }
}