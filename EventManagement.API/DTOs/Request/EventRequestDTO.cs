using EventManagement.Domain.Enums;

namespace EventManagement.API.DTOs.Request;

// DTO PARA CREAR EVENTO

public class EventRequestDTO
{
    public string Name { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public string Location { get; set; } = string.Empty;

    public int VenueId { get; set; }

    public int OrganizerId { get; set; }
    public EventStatus Status { get; set; }
}