using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities.Blog;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class PostRepository(RootDbContext dbContext) : IPostRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Post entity)
    {
        await _dbContext.Posts.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Posts.FirstOrDefaultAsync(post => post.Id == id);
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await _dbContext.Posts.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Post entity)
    {
        var post = await GetByIdAsync(entity.Id);

        if (post is null)
            return false;

        post.Content = entity.Content;
        post.Image = entity.Image;
        post.Title = entity.Title;
        post.ModifiedAt = DateTime.Now;
        // post.ModifiedABy = 

        _dbContext.Update(post);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var post = await GetByIdAsync(id);

        if (post is null)
            return false;

        _dbContext.Posts.Remove(post);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}