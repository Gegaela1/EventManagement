using AutoMapper;
using EventManagement.API.DTOs.Request;
using EventManagement.API.DTOs.Response;
using EventManagement.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EventRequestDTO, Event>();
        CreateMap<Event, EventResponseDTO>();
    }
}
