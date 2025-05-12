using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class GuideRepository(RootDbContext dbContext) : IGuideRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Guide entity)
    {
        await _dbContext.Guides.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Guide?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Guides
            .Include(g => g.User)
            .FirstOrDefaultAsync(guide => guide.Id == id);
    }

    public async Task<IEnumerable<Guide>> GetAllAsync()
    {
        return await _dbContext.Guides.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Guide entity)
    {
        var guide = await GetByIdAsync(entity.Id);

        if (guide is null)
            return false;

        guide.Name = entity.Name;
        guide.Description = entity.Description;
        guide.Location = entity.Location;
        guide.Idioms = entity.Idioms;
        guide.ModifiedAt = DateTime.Now;
        // guide.ModifiedBy = 

        _dbContext.Update(guide);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var guide = await GetByIdAsync(id);

        if (guide is null)
            return false;

        _dbContext.Guides.Remove(guide);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}