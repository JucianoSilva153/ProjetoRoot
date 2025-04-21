using Root.Domain.Entities.Blog;
using Root.Domain.Interfaces;

namespace Root.Persistence.Repositories;

public class PostRepository : IPostRepository
{
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