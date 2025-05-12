using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.ClientDtos;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class ClientService(HttpClient client, LocalStorageService localStorageService)
{
    public async Task<List<ListClientsDto>> GetAllClientsAsync()
    {
        try
        {
            var result = await client.GetFromJsonAsync<List<ListClientsDto>>("/clients");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar clientes => " + e);
        }

        return [];
    }

    public async Task<ListClientsDto?> GetClientByIdAsync(Guid clientId)
    {
        try
        {
            var result = await client.GetFromJsonAsync<ListClientsDto?>($"/clients/{clientId}");
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao procurar clientes => " + e);
        }

        return null;
    }

    public async Task<bool> CreateNewClientAsync(CreateClientDto newClient)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/clients", newClient);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar um novo administrador => " + e);
        }

        return false;
    }

    public async Task<bool> DeleteClientAsync(Guid clientId)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.DeleteAsync($"/clients/{clientId}");
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar clientes => " + e);
        }

        return false;
    }

    public async Task<bool> UpdateClientAsync(UpdateClientDto newClient)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/clients", newClient);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar o cliente => " + e);
        }

        return false;
    }

    private async Task SetAuthorizationHeaderAsync()
    {
        var json = await localStorageService.GetItemAsync("currentUser");
        if (json is not null)
        {
            var token = (JsonSerializer.Deserialize<LoginListUserDto>(json))!.Token;
            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}