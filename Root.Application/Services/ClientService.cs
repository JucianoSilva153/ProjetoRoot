using Root.Application.DTOs.ClientDtos;
using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class ClientService(IClientRepository clientRepository)
{
    public async Task<bool> CreateClientAsync(CreateClientDto dto)
    {
        try
        {
            var client = new Client
            {
                UserId = dto.UserId,
                BirthDate = dto.BirthDate,
                Nationality = dto.Nationality,
                Name = dto.Name,
                Surname = dto.Surname
            };

            return await clientRepository.CreateAsync(client);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao criar cliente: " + ex.Message);
        }

        return false;
    }

    public async Task<List<ListClientsDto>> ListAllClientsAsync()
    {
        try
        {
            var clients = await clientRepository.GetAllAsync();

            return clients.Select(c => new ListClientsDto
            {
                Id = c.Id,
                UserId = c.UserId,
                Nationality = c.Nationality,
                Name = c.Name,
                Surname = c.Surname,
                BirthDate = c.BirthDate,
                UserName = c.User.UserName
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar clientes: " + ex.Message);
        }

        return [];
    }

    public async Task<ListClientsDto?> GetClientByIdAsync(Guid id)
    {
        try
        {
            var client = await clientRepository.GetByIdAsync(id);
            if (client is null)
                return null;

            return new ListClientsDto
            {
                Id = client.Id,
                UserId = client.UserId,
                Nationality = client.Nationality,
                Name = client.Name,
                Surname = client.Surname,
                BirthDate = client.BirthDate,
                UserName = client.User.UserName 
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar cliente: " + ex.Message);
        }

        return null;
    }

    public async Task<bool> UpdateClientAsync(UpdateClientDto dto)
    {
        try
        {
            var client = await clientRepository.GetByIdAsync(dto.Id);
            if (client is null)
                return false;

            client.Nationality = dto.Nationality ?? client.Nationality;
            client.Name = dto.Name ?? client.Name;
            client.Surname = dto.Surname ?? client.Surname;
            client.BirthDate = dto.BirthDate ?? client.BirthDate;
            
            return await clientRepository.UpdateAsync(client);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar cliente: " + ex.Message);
        }

        return false;
    }

    public async Task<bool> DeleteClientAsync(Guid id)
    {
        try
        {
            return await clientRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao deletar cliente: " + ex.Message);
        }

        return false;
    }
}
