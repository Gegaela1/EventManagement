using EventManagement.Domain.Enums;

namespace EventManagement.API.DTOs.Response;

// DTO PARA RESPUESTA
public class EventResponseDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public string Location { get; set; } = string.Empty;
    public EventStatus Status { get; set; }
}