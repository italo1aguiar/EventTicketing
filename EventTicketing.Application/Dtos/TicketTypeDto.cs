namespace EventTicketing.Application.Dtos;

public class TicketTypeDto
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public List<TicketPricePeriodDto> TicketPricePeriods { get; set; }
}