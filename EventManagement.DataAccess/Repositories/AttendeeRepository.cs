using EventManagement.DataAccess.Context;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces.Repositories;

public class AttendeeRepository : GenericRepository<Attendee>, IAttendeeRepository
{
    public AttendeeRepository(EventDbContext context) : base(context)
    {
    }
}
