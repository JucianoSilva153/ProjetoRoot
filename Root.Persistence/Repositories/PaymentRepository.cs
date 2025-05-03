using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class PaymentRepository(RootDbContext dbContext) : IPaymentRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public async Task<bool> CreateAsync(Payment entity)
    {
        await _dbContext.Payments.AddAsync(entity);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<Payment?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Payments.FirstOrDefaultAsync(pay => pay.Id == id);
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await _dbContext.Payments.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Payment entity)
    {
        var pay = await GetByIdAsync(entity.Id);

        if (pay is null)
            return false;

        pay.PaymentMethod = entity.PaymentMethod;
        pay.PaymentValue = entity.PaymentValue;
        pay.ModifiedAt = DateTime.Now;
        // pay.ModifiedBy = 

        _dbContext.Update(pay);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var pay = await GetByIdAsync(id);

        if (pay is null)
            return false;

        _dbContext.Payments.Remove(pay);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}