namespace EventManagement.API.DTOs.Request;

public class TicketRequestDTO
{
    public decimal Price { get; set; }
    public int EventId { get; set; }
    public int AttendeeId { get; set; }
}
