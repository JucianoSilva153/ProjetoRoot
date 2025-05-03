using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities.Packages;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class ActivityRepository(RootDbContext dbContext) : IActivityRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Activity entity)
    {
        await _dbContext.Activities.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Activity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Activities.FirstOrDefaultAsync(activity => activity.Id == id);
    }

    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await _dbContext.Activities.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Activity entity)
    {
        var activity = await GetByIdAsync(entity.Id);

        if (activity is null)
            return false;

        activity.Name = entity.Name;
        activity.Type = entity.Type;
        activity.Description = entity.Description;
        activity.Price = entity.Price;
        activity.DurationTime = entity.DurationTime;
        activity.ModifiedAt = DateTime.Now;
        // activity.ModifiedBy = 

        _dbContext.Update(activity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var activity = await GetByIdAsync(id);

        if (activity is null)
            return false;

        _dbContext.Activities.Remove(activity);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}