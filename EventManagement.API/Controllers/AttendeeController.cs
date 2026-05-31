using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Domain.Entities;
using EventManagement.API.DTOs.Request;
using EventManagement.API.DTOs.Response;

// CONTROLLER: ATTENDEE

[ApiController]
[Route("api/[controller]")]
public class AttendeeController : ControllerBase
{
    private readonly AttendeeService _service;
    private readonly IMapper _mapper;

    public AttendeeController(AttendeeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/Attendee

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();
        var result = _mapper.Map<IEnumerable<AttendeeResponseDTO>>(data);
        return Ok(result);
    }

    // POST: api/Attendee

    [HttpPost]
    public async Task<IActionResult> Create(AttendeeRequestDTO dto)
    {
        var entity = _mapper.Map<Attendee>(dto);
        var result = await _service.CreateAsync(entity);
        var response = _mapper.Map<AttendeeResponseDTO>(result);

        return Ok(response);
    }
}
