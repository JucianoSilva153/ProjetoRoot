using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.AdminDtos;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class AdministratorService(HttpClient client, LocalStorageService localStorageService)
{
    public async Task<List<ListAdminDto>> GetAllAdminsAsync()
    {
        try
        {
            var result = await client.GetFromJsonAsync<List<ListAdminDto>>("/administrators");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar Administradores => " + e);
        }

        return [];
    }

    public async Task<ListAdminDto?> GetAdminByIdAsync(Guid adminId)
    {
        try
        {
            var result = await client.GetFromJsonAsync<ListAdminDto?>($"/administrators/{adminId}");
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao procurar administradores => " + e);
        }

        return null;
    }

    public async Task<bool> CreateNewAdminAsync(CreateAdministratorDto newAdmin)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/administrators", newAdmin);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar um novo administrador => " + e);
        }

        return false;
    }

    public async Task<bool> DeleteAdminAsync(Guid adminId)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.DeleteAsync($"/administrators/{adminId}");
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar administrador => " + e);
        }

        return false;
    }

    public async Task<bool> UpdateAdminAsync(UpdateAdminDto newAdmin)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/administrators", newAdmin);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar o administrador => " + e);
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