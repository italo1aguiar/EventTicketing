namespace EventTicketing.Domain.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int TicketTypeId { get; set; }

    // Relationship: Many Tickets to One TicketType
    public TicketType TicketType { get; set; }
}