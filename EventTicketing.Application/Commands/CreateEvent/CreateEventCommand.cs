using MediatR;

namespace EventTicketing.Application.Commands.CreateEvent;

public class CreateEventCommand : IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int OrganizerId { get; set; }
    public int LocationId { get; set; }
    public int CategoryId { get; set; }
    
    public CreateEventCommand(string name, string description, DateTime date, int organizerId, int locationId, int categoryId)
    {
        Name = name;
        Description = description;
        Date = date;
        OrganizerId = organizerId;
        LocationId = locationId;
        CategoryId = categoryId;
    }
}