namespace EventManagement.Domain.Entities;

// Clase base para todas las entidades
public abstract class AuditBase
{
    public int Id { get; set; }

    // Fecha de creación automática
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Fecha de actualización (nullable)
    public DateTime? UpdatedAt { get; set; }
}
