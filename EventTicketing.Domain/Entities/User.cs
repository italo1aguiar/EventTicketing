namespace EventTicketing.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    // Relationship: One User to Many Orders
    public ICollection<Order> Orders { get; set; }
}