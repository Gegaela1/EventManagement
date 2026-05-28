using Microsoft.AspNetCore.Mvc;
using EventManagement.DataAccess.Context;
using EventManagement.Domain.Entities;

// CONTROLLER: TICKET
[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly EventDbContext _context;

    public TicketController(EventDbContext context)
    {
        _context = context;
    }

    // GET: api/Ticket
    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _context.Tickets.ToList();
        return Ok(data);
    }

    // POST: api/Ticket
    [HttpPost]
    public async Task<IActionResult> Create(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return Ok(ticket);
    }
}
