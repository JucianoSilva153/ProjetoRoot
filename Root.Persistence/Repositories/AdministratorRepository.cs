using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Persistence.Repositories;

public class AdministratorRepository : IAdministratorRepository
{
    public Task<bool> CreateAsync(Administrator entity)
    {
        throw new NotImplementedException();
    }

    public Task<Administrator?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Administrator>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Administrator entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}