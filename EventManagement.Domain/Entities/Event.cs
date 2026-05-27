namespace EventManagement.Domain.Entities;

// Representa un evento del sistema
public class Event : AuditBase
{
    public string Name { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public string Location { get; set; } = string.Empty;
}
