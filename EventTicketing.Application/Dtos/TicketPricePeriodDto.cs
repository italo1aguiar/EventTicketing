namespace EventTicketing.Application.Dtos;

public class TicketPricePeriodDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Quantity { get; set; }
    public bool IsSoldOut { get; set; }
}