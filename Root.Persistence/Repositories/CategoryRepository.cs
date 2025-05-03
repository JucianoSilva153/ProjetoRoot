using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities.Blog;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class CategoryRepository(RootDbContext dbContext) : ICategoryRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Category entity)
    {
        await _dbContext.PostCategories.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _dbContext.PostCategories.FirstOrDefaultAsync(cat => cat.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _dbContext.PostCategories.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Category entity)
    {
        var cat = await GetByIdAsync(entity.Id);

        if (cat is null)
            return false;

        cat.Title = entity.Title;
        cat.ModifiedAt = DateTime.Now;
        // cat.ModifiedBy = 

        _dbContext.Update(cat);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await GetByIdAsync(id);

        if (category is null)
            return false;

        _dbContext.PostCategories.Remove(category);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}