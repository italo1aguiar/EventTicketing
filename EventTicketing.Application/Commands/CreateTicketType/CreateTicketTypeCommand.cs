using EventTicketing.Domain.Entities;
using MediatR;

namespace EventTicketing.Application.Commands.CreateTicket;

public class CreateTicketTypeCommand : IRequest
{
    public int EventId { get; set; }
    public string Name { get; set; }
    public List<TicketPricePeriodDto> TicketPricePeriods { get; set; }
    public class TicketPricePeriodDto
    {
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
    }
}
