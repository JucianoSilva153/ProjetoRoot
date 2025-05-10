using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class UserService(HttpClient client, LocalStorageService localStorageService)
{
    public async Task<bool> NewUserAsync(CreateUserDto newUser)
    {
        try
        {
            var result = await client.PostAsJsonAsync("users", newUser);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar nova conta -> " + e);
        }

        return false;
    }

    public async Task<LoginListUserDto?> LoginAsync(LoginUserDto loginDto)
    {
        try
        {
            var result = await client.PostAsJsonAsync("/users/login", loginDto);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<LoginListUserDto>();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar fazer login -> " + e);
        }

        return null;
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