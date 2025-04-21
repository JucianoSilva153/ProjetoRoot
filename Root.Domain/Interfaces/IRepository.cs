namespace Root.Domain.Interfaces;

public interface IRepository<T>
{
    Task<bool> CreateAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
}
