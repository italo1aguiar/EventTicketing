using AutoMapper;
using EventTicketing.Application.Dtos;
using EventTicketing.Domain.Entities;

namespace EventTicketing.Application.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Event, EventDto>()
            .ForMember(dest => dest.Organizer,
                opt => opt.MapFrom(src => src.Organizer))
            .ForMember(dest => dest.Location,
                opt => opt.MapFrom(src => src.Location))
            .ForMember(dest => dest.EventCategory,
                opt => opt.MapFrom(src => src.EventCategory))
            .ForMember(dest => dest.TicketTypes,
                opt => opt.MapFrom(src => src.TicketTypes));

        CreateMap<Organizer, EventOrganizerDto>();
        CreateMap<Location, EventLocationDto>();
        CreateMap<EventCategory, EventCategoryDto>();
        CreateMap<TicketType, EventTicketTypeDto>();
    }
}
