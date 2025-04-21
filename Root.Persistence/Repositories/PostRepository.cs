using Root.Domain.Entities.Blog;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class PostRepository(RootDbContext dbContext) : IPostRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public Task<bool> CreateAsync(Post entity)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Post entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}