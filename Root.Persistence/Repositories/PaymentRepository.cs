using Root.Domain.Entities;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class PaymentRepository(RootDbContext dbContext) : IPaymentRepository
{
    private readonly RootDbContext _dbContext = dbContext;

    public Task<bool> CreateAsync(Payment entity)
    {
        throw new NotImplementedException();
    }

    public Task<Payment?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Payment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Payment entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}