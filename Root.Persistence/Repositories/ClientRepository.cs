using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    public Task<bool> CreateAsync(Client entity)
    {
        throw new NotImplementedException();
    }

    public Task<Client?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Client>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Client entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}