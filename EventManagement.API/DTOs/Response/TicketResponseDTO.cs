namespace EventManagement.API.DTOs.Response;

public class TicketResponseDTO
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int EventId { get; set; }
    public int AttendeeId { get; set; }
}
