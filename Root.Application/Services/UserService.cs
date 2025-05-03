using Root.Application.DTOs.UserDtos;
using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class UserService(IUserRepository userRepository)
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
}