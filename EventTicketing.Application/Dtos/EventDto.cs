namespace EventTicketing.Application.Dtos;

public class EventDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    // Represent related entities as simplified DTOs
    public EventLocationDto Location { get; set; }
    public EventOrganizerDto Organizer { get; set; }
    public EventCategoryDto EventCategory { get; set; }
    public List<EventTicketTypeDto> TicketTypes { get; set; }
}

public class EventTicketTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public List<TicketPricePeriodDto> TicketPricePeriods { get; set; }
}

public class EventOrganizerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class EventLocationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}

public class EventCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class TicketPricePeriodDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}