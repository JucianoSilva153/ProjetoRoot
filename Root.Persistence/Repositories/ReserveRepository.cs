using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities;
using Root.Domain.Enums;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class ReserveRepository(RootDbContext dbContext) : IReserveRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Reserve entity)
    {
        await _dbContext.Reserves.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Reserve?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Reserves.FirstOrDefaultAsync(reserve => reserve.Id == id);
    }

    public async Task<IEnumerable<Reserve>> GetAllAsync()
    {
        return await _dbContext.Reserves
            .Include(r => r.Client)
                .ThenInclude(c => c.User)
            .Include(r => r.Guide)
                .ThenInclude(g => g.User)
            .Include(r => r.Package)
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(Reserve entity)
    {
        var reserve = await GetByIdAsync(entity.Id);

        if (reserve is null)
            return false;

        reserve.ClientId = entity.ClientId;
        reserve.PackageId = entity.PackageId;
        reserve.TotalPrice = entity.TotalPrice;
        reserve.PeopleCount = entity.PeopleCount;
        reserve.Date = entity.Date;
        reserve.ModifiedAt = DateTime.Now;
        // reserve.ModifiedBy = 

        _dbContext.Update(reserve);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var reserve = await GetByIdAsync(id);

        if (reserve is null)
            return false;

        _dbContext.Reserves.Remove(reserve);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> CancelReserveAsync(Guid reserveId)
    {
        var reserve = await GetByIdAsync(reserveId);
        if(reserve is null)
            return false;
        reserve.Status = ReserveStatus.Cancelled;
        reserve.ModifiedAt = DateTime.Now;
        
        _dbContext.Update(reserve);
        await _dbContext.SaveChangesAsync();
        
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }
}