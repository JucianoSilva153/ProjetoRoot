using Root.Application.DTOs.UserDtos;
using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class UserService(IUserRepository userRepository, 
    IAdministratorRepository administratorRepository, 
    IClientRepository clientRepository,
    IGuideRepository guideRepository)
{
    public async Task<bool> CreateUserAsync(CreateUserDto userDto)
    {
        try
        {
            return await userRepository.CreateAsync(new User()
            {
                UserName = userDto.UserName,
                Contact = userDto.Contact,
                Email = userDto.Email,
                Password = userDto.Password,
                Type = userDto.Type,
            });
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar novo Usuario!!!");
        }

        return false;
    }

    public async Task<List<ListUserDto>> ListAllUsersAsync()
    {
        try
        {
            var users = await userRepository.GetAllAsync();
            return users.Select(u => new ListUserDto()
            {
                UserName = u.UserName,
                Contact = u.Contact,
                Email = u.Email,
                Type = u.Type,
                Id = u.Id
            }).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar Procurar os usuarios!!!");
        }

        return [];
    }

    public async Task<ListUserDto?> ListUserAsync(Guid userId)
    {
        try
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user is null)
                return null;
            return new ListUserDto
            {
                Id = user.Id,
                Contact = user.Contact,
                Email = user.Email,
                Type = user.Type,
                UserName = user.UserName
            };
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar procurar o cliente!!!");
        }

        return null;
    }
    

    public async Task<bool> UpdateUserAsync(UpdateUserDto userDto)
    {
        try
        {
            var userToUpdate = await userRepository.GetByIdAsync(userDto.Id);
            if (userToUpdate is null)
                return false;
            

            userToUpdate.UserName = userDto.UserName ?? userToUpdate.UserName;
            userToUpdate.Contact = userDto.Contact ?? userToUpdate.Contact;
            userToUpdate.Email = userDto.Email ?? userToUpdate.Email;
            userToUpdate.Type = userDto.Type ?? userToUpdate.Type;

            return await userRepository.UpdateAsync(userToUpdate);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar Usuario!!!");
        }

        return false;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        try
        {
            return await userRepository.DeleteAsync(userId);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar Usuario!!!");
        }

        return false;
    }

    public async Task<Guid?> GetUserSpecificTypeIdAsync(Guid userId)
    {
        try
        {
            var admin = (await administratorRepository.GetAllAsync())
                .FirstOrDefault(a => a.UserId == userId);
            if (admin is not null)
                return admin.Id;
            
            var guide = (await guideRepository.GetAllAsync())
                .FirstOrDefault(a => a.UserId == userId);
            if (guide is not null)
                return guide.Id;
            
            var client = (await clientRepository.GetAllAsync())
                .FirstOrDefault(a => a.UserId == userId);
            if (client is not null)
                return client.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar procurar Id" + e);
        }

        return null;
    }
    
    public async Task<ListUserDto?> LoginAsync(LoginUserDto userDto)
    {
        try
        {
            var users = await userRepository.GetAllAsync();
            var currentUser = users.FirstOrDefault(u => (u.Email == userDto.Email && u.Password == userDto.Password)
                                                        || (u.UserName == userDto.UserName &&
                                                            u.Password == userDto.Password));

            if (currentUser is not null)
            {
                return new ListUserDto
                {
                    Id = currentUser.Id,
                    Contact = currentUser.Contact,
                    Email = currentUser.Email,
                    Type = currentUser.Type,
                    UserName = currentUser.UserName
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar fazer login!!!");
        }

        return null;
    }
}