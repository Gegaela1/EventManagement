using EventManagement.DataAccess.Context;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    public TicketRepository(EventDbContext context) : base(context)
    {
    }
}
