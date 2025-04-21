using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public Task<bool> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}