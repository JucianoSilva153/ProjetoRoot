using Root.Application.DTOs.PackageDtos;
using Root.Domain.Entities;
using Root.Domain.Entities.Packages;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class PackageService(IPackageRepository packageRepository)
{
    public async Task<bool> CreatePackageAsync(CreatePackageDto dto)
    {
        try
        {
            var package = new Package
            {
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type,
                Activities = dto.ActivityIds?.Select(id => new Activity { Id = id }).ToList() ?? new()
            };

            return await packageRepository.CreateAsync(package);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao criar pacote: " + ex.Message);
        }

        return false;
    }

    public async Task<List<ListPackageDto>> ListAllPackagesAsync()
    {
        try
        {
            var packages = await packageRepository.GetAllAsync();
            return packages.Select(p => new ListPackageDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Type = p.Type,
                ActivityNames = p.Activities?.Select(a => a.Name).ToList() ?? new()
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar pacotes: " + ex.Message);
        }

        return [];
    }

    public async Task<ListPackageDto?> GetPackageByIdAsync(Guid id)
    {
        try
        {
            var package = await packageRepository.GetByIdAsync(id);
            if (package is null)
                return null;

            return new ListPackageDto
            {
                Id = package.Id,
                Name = package.Name,
                Description = package.Description,
                Type = package.Type,
                ActivityNames = package.Activities?.Select(a => a.Name).ToList() ?? new()
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar pacote: " + ex.Message);
        }

        return null;
    }

    public async Task<bool> UpdatePackageAsync(UpdatePackageDto dto)
    {
        try
        {
            var package = await packageRepository.GetByIdAsync(dto.Id);
            if (package is null)
                return false;

            package.Name = dto.Name ?? package.Name;
            package.Description = dto.Description ?? package.Description;
            package.Type = dto.Type ?? package.Type;
            if (dto.ActivityIds is not null)
                package.Activities = dto.ActivityIds.Select(id => new Activity { Id = id }).ToList();

            return await packageRepository.UpdateAsync(package);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar pacote: " + ex.Message);
        }

        return false;
    }

    public async Task<bool> DeletePackageAsync(Guid id)
    {
        try
        {
            return await packageRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao deletar pacote: " + ex.Message);
        }

        return false;
    }
}
