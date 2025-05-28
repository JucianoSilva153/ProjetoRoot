using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.CategoryDtos;
using Root.Application.DTOs.PostDtos;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class PostService(HttpClient client, LocalStorageService localStorageService)
{
    public async Task<List<ListPostDto>> GetAllPostsAsync()
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.GetFromJsonAsync<List<ListPostDto>>("/posts");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar artigos => " + e);
        }

        return [];
    }
    
    public async Task<List<ListCategoryDto>> GetAllCategoriesAsync()
    {
        try
        {
            var result = await client.GetFromJsonAsync<List<ListCategoryDto>>("/categories");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar categorias => " + e);
        }

        return [];
    }

    public async Task<ListPostDto?> GetPostByIdAsync(Guid postId)
    {
        try
        {
            var result = await client.GetFromJsonAsync<ListPostDto?>($"/posts/{postId}");
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao procurar artigo => " + e);
        }

        return null;
    }

    public async Task<bool> CreateNewPostAsync(CreatePostDto newPost)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/posts", newPost);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar um novo artigo => " + e);
        }

        return false;
    }
    
    public async Task<bool> CreateNewCategoryAsync(CreateCategoryDto newCategory)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/categories", newCategory);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar uma nova categoria => " + e);
        }

        return false;
    }

    public async Task<bool> DeletePostAsync(Guid postId)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.DeleteAsync($"/posts/{postId}");
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar artigo => " + e);
        }

        return false;
    }

    public async Task<bool> UpdatePostAsync(UpdatePostDto newPost)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/posts", newPost);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar o artigo => " + e);
        }

        return false;
    }
    
    public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto newCategory)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/categories", newCategory);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar a categoria => " + e);
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