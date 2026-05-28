using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Domain.Entities;
using EventManagement.API.DTOs.Request;
using EventManagement.API.DTOs.Response;

// CONTROLLER EVENT
[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly EventService _service;
    private readonly IMapper _mapper;

    public EventController(EventService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();

        // ENTITY → DTO
        var result = _mapper.Map<IEnumerable<EventResponseDTO>>(data);

        return Ok(result);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(EventRequestDTO dto)
    {
        // DTO → ENTITY
        var entity = _mapper.Map<Event>(dto);

        var result = await _service.CreateAsync(entity);

        // ENTITY → DTO
        var response = _mapper.Map<EventResponseDTO>(result);

        return Ok(response);
    }
}
