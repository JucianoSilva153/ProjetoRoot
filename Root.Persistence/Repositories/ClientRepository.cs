using Root.Domain.Entities;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class ClientRepository(RootDbContext dbContext) : IClientRepository
{
    private readonly RootDbContext _dbContext = dbContext;

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