using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class AdministratorRepository(RootDbContext dbContext) : IAdministratorRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Administrator entity)
    {
        await _dbContext.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Administrator?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Administrators
            .Include(g => g.User)
            .FirstOrDefaultAsync(guide => guide.Id == id);
    }

    public async Task<IEnumerable<Administrator>> GetAllAsync()
    {
        return await _dbContext.Administrators.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Administrator entity)
    {
        var admin = await GetByIdAsync(entity.Id);

        if (admin is null)
            return false;

        admin.Name = entity.Name;
        admin.Surname = entity.Surname;
        admin.AcessLeves = entity.AcessLeves;
        admin.Role = entity.Role;
        admin.ModifiedAt = DateTime.Now; 
        // admin.ModifiedBy =  

        _dbContext.Update(admin);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var admin = await GetByIdAsync(id);

        if (admin is null)
            return false;

        _dbContext.Administrators.Remove(admin);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}