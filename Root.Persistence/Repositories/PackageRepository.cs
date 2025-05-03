using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities.Packages;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class PackageRepository(RootDbContext dbContext) : IPackageRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Package entity)
    {
        await _dbContext.Packages.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Package?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Packages.FirstOrDefaultAsync(pack => pack.Id == id);
    }

    public async Task<IEnumerable<Package>> GetAllAsync()
    {
        return await _dbContext.Packages.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Package entity)
    {
        var pack = await GetByIdAsync(entity.Id);

        if (pack is null)
            return false;

        pack.Name = entity.Name;
        pack.Type = entity.Type;
        pack.Description = entity.Description;
        pack.ModifiedAt = DateTime.Now;
        // pack.ModifiedBy = 

        _dbContext.Update(pack);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var pack = await GetByIdAsync(id);

        if (pack is null)
            return false;

        _dbContext.Packages.Remove(pack);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}