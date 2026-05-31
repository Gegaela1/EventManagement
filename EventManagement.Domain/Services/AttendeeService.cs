using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;

public class AttendeeService
{
    private readonly IAttendeeRepository _repository;

    public AttendeeService(IAttendeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Attendee>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Attendee> CreateAsync(Attendee attendee)
        => await _repository.CreateAsync(attendee);
}
