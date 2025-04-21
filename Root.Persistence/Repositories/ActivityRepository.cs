using Root.Domain.Entities.Packages;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class ActivityRepository(RootDbContext dbContext) : IActivityRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public Task<bool> CreateAsync(Activity entity)
    {
        throw new NotImplementedException();
    }

    public Task<Activity?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Activity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Activity entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}