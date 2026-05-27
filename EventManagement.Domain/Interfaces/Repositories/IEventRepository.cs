using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Interfaces.Repositories;

public interface IEventRepository : IGenericRepository<Event>
{
    Task<Event?> GetByNameAsync(string name);
}
