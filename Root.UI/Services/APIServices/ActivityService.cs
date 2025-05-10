using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.ActivityDto;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class ActivityService(HttpClient client, LocalStorageService localStorageService)
{
    public async Task<List<ListActivityDto>> GetAllActivitiesAsync()
    {
        try
        {
            var result = await client.GetFromJsonAsync<List<ListActivityDto>>("/activities");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar atividades => " + e);
        }

        return [];
    }

    public async Task<bool> CreateNewActivitieAsync(CreateActivityDto newActivity)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/activities", newActivity);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar uma nova atividade => " + e);
        }

        return false;
    }

    public async Task<bool> DeleteActivityAsync(Guid activityId)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.DeleteAsync($"/activities/{activityId}");
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar atividade => " + e);
        }

        return false;
    }

    public async Task<bool> UpdateActivityAsync(UpdateActivityDto newActivity)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/activities", newActivity);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar uma nova atividade => " + e);
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