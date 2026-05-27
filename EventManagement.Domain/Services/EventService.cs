using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;

// Lógica de negocio
public class EventService
{
    private readonly IEventRepository _repository;

    public EventService(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Event> CreateAsync(Event ev)
    {
        // Validación de negocio
        if (ev.Date < DateTime.Now)
            throw new InvalidOperationException("No puede crear eventos en el pasado");

        return await _repository.CreateAsync(ev);
    }
}
