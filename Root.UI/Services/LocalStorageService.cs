using Microsoft.JSInterop;

namespace Root.UI.Services;

public class LocalStorageService
{
    private readonly IJSRuntime _js;

    public LocalStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetItemAsync(string key, string value)
    {
        await _js.InvokeVoidAsync("localStorage.setItem", key, value);
    }

    public async Task<string?> GetItemAsync(string key)
    {
        return await _js.InvokeAsync<string?>("localStorage.getItem", key);
    }

    public async Task RemoveItemAsync(string key)
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", key);
    }

    public async Task ClearAsync()
    {
        await _js.InvokeVoidAsync("localStorage.clear");
    }
}