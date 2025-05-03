using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities;
using Root.Domain.Enums;
using Root.Domain.Interfaces;
using Root.Persistence.Context;

namespace Root.Persistence.Repositories;

public class UserRepository(
    RootDbContext dbContext,
    IAdministratorRepository adminRepository,
    IClientRepository clientRepository,
    IGuideRepository guideRepository) : IUserRepository
{
    private readonly RootDbContext _dbContext = dbContext;
    private readonly IAdministratorRepository _adminRepository = adminRepository;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IGuideRepository _guideRepository = guideRepository;

    public async Task<bool> CreateAsync(User entity)
    {
        var newuser = await _dbContext.Users.AddAsync(entity);

        if (newuser.Entity.Type == UserType.Administrator)
        {
            await adminRepository.CreateAsync(new Administrator()
            {
                User = newuser.Entity,
                UserId = newuser.Entity.Id,
                Name = newuser.Entity.UserName,
                Surname = "",
            });
        }
        else if (newuser.Entity.Type == UserType.Client)
        {
            await clientRepository.CreateAsync(new Client()
            {
                User = newuser.Entity,
                UserId = newuser.Entity.Id,
                Name = newuser.Entity.UserName,
                Surname = ""
            });
        }
        else if (newuser.Entity.Type == UserType.Guide)
        {
            await guideRepository.CreateAsync(new Guide()
            {
                User = newuser.Entity,
                UserId = newuser.Entity.Id,
                Name = newuser.Entity.UserName,
                Surname = ""
            });
        }

        var entriesCount = await _dbContext.SaveChangesAsync();
        if (!(entriesCount > 0))
            return false;


        return true;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<bool> UpdateAsync(User entity)
    {
        var user = await GetByIdAsync(entity.Id);

        if (user is null)
            return false;

        user.UserName = entity.UserName;
        user.Contact = entity.Contact;
        user.Type = entity.Type;
        user.Email = entity.Email;

        _dbContext.Update(user);
        var entriesCount = await _dbContext.SaveChangesAsync();
        if (entriesCount > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null)
            return false;

        _dbContext.Users.Remove(user);
        int entriesCount = await _dbContext.SaveChangesAsync();

        if (entriesCount > 0)
            return true;
        return false;
    }
}