using System.Text.Json;
using Root.Application.DTOs.PackageDtos;
using Root.Common.Abstractions;
using Root.UI.Services.APIServices;

namespace Root.UI.Services;

public class CartService(
    PackageService packageService,
    ReserveService reserveService,
    LocalStorageService localStorageService)
{
    public async Task<List<ListPackageDto>> ListItemsAsync(List<Guid> itemsIds)
    {
        List<ListPackageDto> list = [];
        foreach (var id in itemsIds)
        {
            var item = await packageService.GetPackageByIdAsync(id);
            if (item is not null)
                list.Add(item);
        }

        return list;
    }

    public async void AddItem(Guid clientId, Guid itemId)
    {
        var cart = await GetCart(clientId);
        if (cart is not null)
        {
            if (!cart.Items.Contains(itemId))
            {
                cart.Items.Add(itemId);
                UpdateCart(cart, clientId);
            }
        }
    }

    public async Task<Cart?> GetCart(Guid clientId)
    {
        Console.WriteLine(clientId);
        var stringJson = await localStorageService.GetItemAsync($"cart_{clientId}");
        return JsonSerializer.Deserialize<Cart>(stringJson!);
    }

    public async Task<bool> CartExists(Guid clientId)
    {
        return await localStorageService.GetItemAsync($"cart_{clientId}") != null;
    }

    public async void UpdateCart(Cart cart, Guid clientId)
    {
        var stringToStore = JsonSerializer.Serialize(cart);
        await localStorageService.SetItemAsync($"cart_{clientId}", stringToStore);
    }

    public async void RegisterCart(Guid clientId)
    {
        Cart cart = new Cart
        {
            Items = [],
            OwnerId = clientId
        };

        var stringToStore = JsonSerializer.Serialize(cart);
        await localStorageService.SetItemAsync($"cart_{clientId}", stringToStore);
    }
}