using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.ReserveDtos;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class ReserveService(HttpClient client, LocalStorageService localStorageService)
{
     public async Task<List<ListReserveDto>> GetAllReservesAsync()
    {
        try
        {
            var result = await client.GetFromJsonAsync<List<ListReserveDto>>("/reserves");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar reservas => " + e);
        }

        return [];
    }
    
    public async Task<ListReserveDto?> GetReserveByIdAsync(Guid guideId)
    {
        try
        {
            var result = await client.GetFromJsonAsync<ListReserveDto?>($"/reserves/{guideId}");
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao procurar reservas => " + e);
        }

        return null;
    }

    public async Task<bool> CreateNewReserveAsync(CreateReserveDto newReserve)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/reserves", newReserve);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar uma nova reserva => " + e);
        }

        return false;
    }
    
    public async Task<bool> DeleteReserveAsync(Guid reserveId)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.DeleteAsync($"/reserves/{reserveId}");
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar reserva => " + e);
        }

        return false;
    }

    public async Task<bool> UpdateReserveAsync(UpdateReserveDto newReserve)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/reserves", newReserve);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar a reserva => " + e);
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