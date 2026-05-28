using System.Net.Sockets;

namespace EventManagement.Domain.Entities;

//Representa una persona que asiste a eventos (asistente)
public class Attendee : AuditBase
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    //Relación con Ticket
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
