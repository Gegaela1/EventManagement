using EventManagement.Domain.Enums;

namespace EventManagement.Domain.Entities;

// Representa un evento del sistema
public class Event : AuditBase
{
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
    
    //Enums
    public EventStatus Status { get; set; }

    // RELACIONES

    //Relación con evento (1:N)
    public int VenueId { get; set; } //llave foránea
    public Venue? Venue { get; set; }

    //Relación con organizador (1:N)
    public int OrganizerId { get; set; }
    public Organizer? Organizer { get; set; }
}