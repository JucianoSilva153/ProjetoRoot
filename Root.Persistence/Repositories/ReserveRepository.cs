using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Persistence.Repositories;

public class ReserveRepository : IReserveRepository
{
    public Task<bool> CreateAsync(Reserve entity)
    {
        throw new NotImplementedException();
    }

    public Task<Reserve?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Reserve>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Reserve entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}