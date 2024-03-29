namespace EventTicketing.Domain.Entities;

public class TicketType
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Name { get; set; }

    // New: Sold-out status
    public bool IsSoldOut { get; set; }

    // New: Relationship: One TicketType to Many TicketPricePeriods
    public ICollection<TicketPricePeriod> TicketPricePeriods { get; set; }

    // Relationship: One TicketType to Many Tickets
    public ICollection<Ticket> Tickets { get; set; }
    
    public int Quantity
    {
        get
        {
            return TicketPricePeriods.Sum(tp => tp.Quantity);
        }
    }
}