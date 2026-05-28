using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Domain.Entities;

//Tabla intermedia (el ticket va a conectar a evento y asistente)
public class Ticket : AuditBase
{
    public decimal Price { get; set; }

    public DateTime PurchaseDate { get; set; }

    // Relación con evento
    public int EventId { get; set; }
    public Event? Event { get; set; }

    // Relación con asistente

    public int AttendeeId { get; set; }
    public Attendee? Attendee { get; set; }
}
