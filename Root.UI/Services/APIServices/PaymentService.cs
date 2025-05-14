using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Root.Application.DTOs.PaymentDtos;
using Root.Application.DTOs.UserDtos;

namespace Root.UI.Services.APIServices;

public class PaymentService(HttpClient client, LocalStorageService localStorageService)
{
        public async Task<List<ListPaymentDto>> GetAllPaymentsAsync()
    {
        try
        {
            var result = await client.GetFromJsonAsync<List<ListPaymentDto>>("/payments");
            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao listar pagamentos => " + e);
        }

        return [];
    }
    
    public async Task<ListPaymentDto?> GetPaymentByIdAsync(Guid guideId)
    {
        try
        {
            var result = await client.GetFromJsonAsync<ListPaymentDto?>($"/payments/{guideId}");
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao procurar pagamento => " + e);
        }

        return null;
    }

    public async Task<bool> CreateNewPaymentAsync(CreatePaymentDto newPayment)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PostAsJsonAsync("/payments", newPayment);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar um novo pagamento => " + e);
        }

        return false;
    }
    
    public async Task<bool> DeletePaymentAsync(Guid paymentId)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.DeleteAsync($"/payments/{paymentId}");
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar eliminar pagamento => " + e);
        }

        return false;
    }

    public async Task<bool> UpdatePaymentAsync(UpdatePaymentDto newPayment)
    {
        try
        {
            await SetAuthorizationHeaderAsync();
            var result = await client.PutAsJsonAsync("/payments", newPayment);
            if (result.IsSuccessStatusCode)
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar atualizar o pagamento => " + e);
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