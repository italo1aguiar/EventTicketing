namespace EventTicketing.Domain.Entities;

public class TicketPricePeriod
{
    public int Id { get; set; }
    public int TicketTypeId { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Quantity { get; set; }
    
    // New: Sold-out status
    public bool IsSoldOut { get; set; }

    // Relationship: Many TicketPricePeriods to One TicketType
    public TicketType TicketType { get; set; }
}