using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;

public class TicketService
{
    private readonly ITicketRepository _repository;

    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Ticket> CreateAsync(Ticket ticket)
        => await _repository.CreateAsync(ticket);
}

