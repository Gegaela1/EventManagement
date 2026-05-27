using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Interfaces.Repositories;

// Restricción: solo entidades que hereden de AuditBase
public interface IGenericRepository<T> where T : AuditBase
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
