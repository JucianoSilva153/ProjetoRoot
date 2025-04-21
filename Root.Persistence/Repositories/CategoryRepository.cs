using Root.Domain.Entities.Blog;
using Root.Domain.Interfaces;

namespace Root.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public Task<bool> CreateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}