using Microsoft.AspNetCore.Mvc;
using EventManagement.DataAccess.Context;
using EventManagement.Domain.Entities;

// CONTROLLER: ATTENDEE

[ApiController]
[Route("api/[controller]")]
public class AttendeeController : ControllerBase
{
    private readonly EventDbContext _context;

    public AttendeeController(EventDbContext context)
    {
        _context = context;
    }

    // GET: api/Attendee

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = _context.Attendees.ToList();
        return Ok(data);
    }

    // POST: api/Attendee

    [HttpPost]
    public async Task<IActionResult> Create(Attendee attendee)
    {
        _context.Attendees.Add(attendee);
        await _context.SaveChangesAsync();

        return Ok(attendee);
    }
}

