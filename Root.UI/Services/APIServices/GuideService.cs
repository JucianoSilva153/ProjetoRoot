using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.GuideDtos;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class GuideService(HttpClient client, LocalStorageService localStorageService)
{
    public async Task<List<ListGuidesDto>> GetAllGuidesAsync()
    {
        try
        {
            var result = await client.GetFromJsonAsync<List<ListGuidesDto>>("/guides");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar Guias => " + e);
        }

        return [];
    }
    
    public async Task<ListGuidesDto?> GetGuideByIdAsync(Guid guideId)
    {
        try
        {
            var result = await client.GetFromJsonAsync<ListGuidesDto?>($"/guides/{guideId}");
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao procurar Guias => " + e);
        }

        return null;
    }

    public async Task<bool> CreateNewGuideAsync(CreateGuideDto newGuide)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/guides", newGuide);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar um novo guia => " + e);
        }

        return false;
    }
    
    public async Task<bool> DeleteGuideAsync(Guid guideId)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.DeleteAsync($"/guides/{guideId}");
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar guia => " + e);
        }

        return false;
    }

    public async Task<bool> UpdateGuideAsync(UpdateGuideDto newGuide)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/guides", newGuide);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar o guia => " + e);
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