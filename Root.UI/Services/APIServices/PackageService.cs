using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.PackageDtos;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class PackageService(HttpClient client, LocalStorageService localStorageService)
{
    public async Task<List<ListPackageDto>> GetAllPackagesAsync()
    {
        try
        {
            var result = await client.GetFromJsonAsync<List<ListPackageDto>>("/packages");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar Pacotes => " + e);
        }

        return [];
    }

    public async Task<bool> CreateNewPackageAsync(CreatePackageDto newPackage)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/packages", newPackage);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar um novo pacote => " + e);
        }

        return false;
    }

    public async Task<bool> DeletePackageAsync(Guid packageId)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.DeleteAsync($"/packages/{packageId}");
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar pacote => " + e);
        }

        return false;
    }
    
    public async Task<bool> UpdatePackageAsync(UpdatePackageDto newPackage)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/packages", newPackage);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar um novo pacote => " + e);
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