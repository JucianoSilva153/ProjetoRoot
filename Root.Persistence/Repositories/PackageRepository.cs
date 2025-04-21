using Root.Domain.Entities.Packages;
using Root.Domain.Interfaces;

namespace Root.Persistence.Repositories;

public class PackageRepository : IPackageRepository
{
    public Task<bool> CreateAsync(Package entity)
    {
        throw new NotImplementedException();
    }

    public Task<Package?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Package>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Package entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}