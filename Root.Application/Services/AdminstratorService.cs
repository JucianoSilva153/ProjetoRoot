using Root.Application.DTOs.AdminDtos;
using Root.Domain.Entities;
using Root.Domain.Enums;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class AdministratorService(IAdministratorRepository administratorRepository)
{
    public async Task<bool> CreateAdministratorAsync(CreateAdministratorDto dto)
    {
        try
        {
            var admin = new Administrator
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Role = dto.Role,
                AcessLeves = dto.AcessLevesIds,
                UserId = dto.UserId
            };

            return await administratorRepository.CreateAsync(admin);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao criar o administrador: " + ex.Message);
        }

        return false;
    }

    public async Task<List<ListAdminDto>> ListAllAdministratorsAsync()
    {
        try
        {
            var admins = await administratorRepository.GetAllAsync();
            return admins.Select(admin => new ListAdminDto()
            {
                Id = admin.Id,
                Name = admin.Name,
                Surname = admin.Surname,
                Role = admin.Role,
                AcessLeves = admin.AcessLeves.ToStringList(),
                UserId = admin.UserId
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar administradores: " + ex.Message);
        }

        return [];
    }

    public async Task<ListAdminDto?> GetAdministratorByIdAsync(Guid id)
    {
        try
        {
            var admin = await administratorRepository.GetByIdAsync(id);
            if (admin is null)
                return null;

            return new ListAdminDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Surname = admin.Surname,
                Role = admin.Role,
                AcessLeves = admin.AcessLeves.ToStringList(),
                UserId = admin.UserId
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar administrador: " + ex.Message);
        }

        return null;
    }

    public async Task<bool> UpdateAdministratorAsync(UpdateAdminDto dto)
    {
        try
        {
            var admin = await administratorRepository.GetByIdAsync(dto.Id);
            if (admin is null)
                return false;

            admin.Name = dto.Name ?? admin.Name;
            admin.Surname = dto.Surname ?? admin.Surname;
            admin.Role = dto.Role ?? admin.Role;
            admin.AcessLeves = dto.AcessLeves ?? admin.AcessLeves;

            return await administratorRepository.UpdateAsync(admin);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar administrador: " + ex.Message);
        }

        return false;
    }

    public async Task<bool> DeleteAdministratorAsync(Guid id)
    {
        try
        {
            return await administratorRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao deletar administrador: " + ex.Message);
        }

        return false;
    }
}
