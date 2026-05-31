using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Domain.Entities;
using EventManagement.API.DTOs.Request;
using EventManagement.API.DTOs.Response;

// CONTROLLER: TICKET
[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly TicketService _service;
    private readonly IMapper _mapper;

    public TicketController(TicketService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/Ticket
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();
        var result = _mapper.Map<IEnumerable<TicketResponseDTO>>(data);
        return Ok(result);
    }

    // POST: api/Ticket
    [HttpPost]
    public async Task<IActionResult> Create(TicketRequestDTO dto)
    {
        var entity = _mapper.Map<Ticket>(dto);
        entity.PurchaseDate = DateTime.UtcNow; // Fecha automática
        var result = await _service.CreateAsync(entity);
        var response = _mapper.Map<TicketResponseDTO>(result);

        return Ok(response);
    }
}
