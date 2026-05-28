namespace EventManagement.Domain.Entities;

// Representa el organizador del evento
public class Organizer : AuditBase
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    // Relación: un Organizer tiene muchos Events
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
