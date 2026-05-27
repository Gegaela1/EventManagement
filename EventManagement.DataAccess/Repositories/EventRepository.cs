using Microsoft.EntityFrameworkCore;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;
using EventManagement.DataAccess.Context;

public class EventRepository : GenericRepository<Event>, IEventRepository
{
    public EventRepository(EventDbContext context) : base(context)
    {
    }

    public async Task<Event?> GetByNameAsync(string name)
    {
        return await _dbSet
            .FirstOrDefaultAsync(e => e.Name.ToLower() == name.ToLower());
    }
}
