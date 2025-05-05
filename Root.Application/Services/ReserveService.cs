using Root.Application.DTOs.ReserveDtos;
using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class ReserveService(IReserveRepository reserveRepository)
{
    public async Task<bool> CreateReserveAsync(CreateReserveDto dto)
    {
        try
        {
            var reserve = new Reserve
            {
                ClientId = dto.ClientId,
                PackageId = dto.PackageId,
                PeopleCount = dto.PeopleCount
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

            return reserves.Select(r => new ListReserveDto
            {
                Id = r.Id,
                ClientId = r.ClientId,
                PackageId = r.PackageId,
                PeopleCount = r.PeopleCount,
                TotalPrice = r.TotalPrice
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
                TotalPrice = reserve.TotalPrice
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
}
