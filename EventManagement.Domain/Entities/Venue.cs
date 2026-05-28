namespace EventManagement.Domain.Entities;

// Representa un lugar donde se realiza el evento
public class Venue : AuditBase
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    // Relación: un Venue tiene muchos Events
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
