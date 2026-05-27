using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Domain.Entities;

namespace EventManagement.API.Controllers;

// Controlador API
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<EventResponseDTO>>(data));
    }

    [HttpPost]
    public async Task<IActionResult> Create(EventRequestDTO dto)
    {
        var entity = _mapper.Map<Event>(dto);
        var result = await _service.CreateAsync(entity);

        return Ok(_mapper.Map<EventResponseDTO>(result));
    }
}
