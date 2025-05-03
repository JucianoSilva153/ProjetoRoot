using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class ClientRepository(RootDbContext dbContext) : IClientRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Client entity)
    {
        await _dbContext.Clients.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Client?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Clients.FirstOrDefaultAsync(client => client.Id == id);
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _dbContext.Clients.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Client entity)
    {
        var client = await GetByIdAsync(entity.Id);

        if (client is null)
            return false;

        client.Name = entity.Name;
        client.Surname = entity.Surname;
        client.Nationality = entity.Nationality;
        client.BirthDate = entity.BirthDate;
        client.ModifiedAt = DateTime.Now;
        // client.ModifiedBy = 

        _dbContext.Update(client);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var client = await GetByIdAsync(id);

        if (client is null)
            return false;

        _dbContext.Clients.Remove(client);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}