using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Root.Application.DTOs.PackageDtos;
using Root.Domain.Entities;
using Root.Domain.Entities.Packages;
using Root.Domain.Enums;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class PackageService(
    IPackageRepository packageRepository,
    IActivityRepository activityRepository,
    IHttpContextAccessor contextAccessor)
{
    public Guid? GetCurrentUserId()
    {
        var currentUser = contextAccessor.HttpContext?.User;
        var userStringId = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Guid.Parse(userStringId!);
    }

    public string GetCurrentUserRole()
    {
        var currentUser = contextAccessor.HttpContext?.User;
        var userrole = currentUser?.FindFirst(ClaimTypes.Role)?.Value;

        return userrole ?? "";
    }


    public async Task<bool> CreatePackageAsync(CreatePackageDto dto)
    {
        try
        {
            var package = new Package
            {
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type,
                BasePrice = dto.PackageBasePrice,
                Activities = dto.ActivityIds?.Select(id => new Activity { Id = id }).ToList() ?? new()
            };

            if (package.Type == PackageType.Custom)
            {
                int count = (await packageRepository.GetAllAsync()).Count() + 1;
                package.Name = $"CP#({count}) - {package.Name}";
                package.CustomPackageClientId = GetCurrentUserId();
            }

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
            foreach (var p in packages)
            {
                Console.WriteLine($"Package: {p.Name}, Atividades: {p.Activities?.Count ?? 0}");
            }
            return packages.Select(p => new ListPackageDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Type = p.Type,
                PackageBasePrice = p.BasePrice,
                CustomPackageOwnerId = p.CustomPackageClientId ??  Guid.Empty,
                ActivitiesPackagePrice = p.Activities.Sum(a => a.Price),
                Duration = (int)p.Activities.Sum(a => a.DurationTime),
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
                PackageBasePrice = package.BasePrice,
                CustomPackageOwnerId = package.CustomPackageClientId!.Value,   
                ActivitiesPackagePrice = package.Activities.Sum(a => a.Price),
                Duration = (int)package.Activities.Sum(a => a.DurationTime),
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
            package.BasePrice = dto.PackageBasePrice ?? package.BasePrice;

            if (dto.ActivityIds is not null)
            {
                var activities = (await activityRepository.GetAllAsync())
                    .Where(a => dto.ActivityIds.Contains(a.Id)).ToList();

                package.Activities = activities;
            }

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