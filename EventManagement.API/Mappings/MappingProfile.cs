using AutoMapper;
using EventManagement.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EventRequestDTO, Event>();
        CreateMap<Event, EventResponseDTO>();
    }
}
