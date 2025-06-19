using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Root.Application.DTOs.ReserveDtos;
using Root.Domain.Entities;
using Root.Domain.Enums;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class ReserveService(IReserveRepository reserveRepository, IHttpContextAccessor contextAccessor)
{
    public Guid? GetCurrentUserId()
    {
        var currentUser = contextAccessor.HttpContext?.User;
        var userStringId = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Guid.Parse(userStringId!);
    }
    
    public UserType GetCurrentUserType()
    {
        var currentUser = contextAccessor.HttpContext?.User;
        var userStringType = currentUser?.FindFirst(ClaimTypes.Role)?.Value;

        if(userStringType == UserType.Administrator.ToFriendlyString())
            return UserType.Administrator;
        if(userStringType == UserType.Guide.ToFriendlyString())
            return UserType.Guide;
        
        return UserType.Client;
    }
    
    public async Task<bool> CreateReserveAsync(CreateReserveDto dto)
    {
        try
        {
            var reserve = new Reserve
            {
                ClientId = dto.ClientId,
                PackageId = dto.PackageId,
                PeopleCount = dto.PeopleCount,
                Date = dto.ReserveDate,
                GuideId = dto.GuideId,
                TotalPrice = dto.TotalPrice
            };

            return await reserveRepository.CreateAsync(reserve);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao criar reserva: " + ex.Message);
        }

        return false;
    }

    public async Task<List<ListReserveDto>> ListAllReservesAsync()
    {
        try
        {
            var reserves = await reserveRepository.GetAllAsync();

            if(GetCurrentUserType() == UserType.Client)
                reserves = reserves.Where(r => r.Client.User.Id == GetCurrentUserId()).ToList();
            if(GetCurrentUserType() == UserType.Guide)
                reserves = reserves.Where(r => r.Guide.User.Id == GetCurrentUserId()).ToList();
            
            return reserves.Select(r => new ListReserveDto
            {
                Id = r.Id,
                ClientId = r.ClientId,
                PackageId = r.PackageId,
                PeopleCount = r.PeopleCount,
                TotalPrice = r.TotalPrice,
                ClientName = r.Client.Name,
                GuideName = r.Guide.Name + " " + r.Guide.Surname,
                ReserveStatus = r.Status,
                PackageName = r.Package.Name,
                ReserveDate = r.Date,
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar reservas: " + ex.Message);
        }

        return [];
    }

    public async Task<ListReserveDto?> GetReserveByIdAsync(Guid id)
    {
        try
        {
            var reserve = await reserveRepository.GetByIdAsync(id);
            if (reserve is null)
                return null;

            return new ListReserveDto
            {
                Id = reserve.Id,
                ClientId = reserve.ClientId,
                PackageId = reserve.PackageId,
                PeopleCount = reserve.PeopleCount,
                TotalPrice = reserve.TotalPrice,
                ReserveStatus = reserve.Status,
                ReserveDate = reserve.Date
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar reserva: " + ex.Message);
        }

        return null;
    }

    public async Task<bool> UpdateReserveAsync(UpdateReserveDto dto)
    {
        try
        {
            var reserve = await reserveRepository.GetByIdAsync(dto.Id);
            if (reserve is null)
                return false;

            reserve.PeopleCount = dto.PeopleCount ?? reserve.PeopleCount;
            reserve.GuideId = dto.GuideId ?? reserve.GuideId; 
            reserve.Date = dto.ReserveDate ?? reserve.Date;
            reserve.Status = dto.ReserveStatus ?? reserve.Status;

            return await reserveRepository.UpdateAsync(reserve);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar reserva: " + ex.Message);
        }

        return false;
    }

    public async Task<bool> DeleteReserveAsync(Guid id)
    {
        try
        {
            return await reserveRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao deletar reserva: " + ex.Message);
        }

        return false;
    }
    
    public async Task<bool> CancelReserveAsync(Guid id)
    {
        try
        {
            return await reserveRepository.CancelReserveAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao cancelar reserva: " + ex.Message);
        }

        return false;
    }
}
