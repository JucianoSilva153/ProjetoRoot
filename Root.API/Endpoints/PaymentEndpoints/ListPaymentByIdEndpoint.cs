using FastEndpoints;
using Root.Application.DTOs.PaymentDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PaymentEndpoints;

public class ListPaymentByIdEndpoint(PaymentService paymentService) : Endpoint<Guid, ListPaymentDto?>
{
    public override void Configure()
    {
        Get("/payments/{paymentId:guid}");
        Tags("Payments");
        AllowAnonymous();
    }

    public override async Task<ListPaymentDto?> ExecuteAsync(Guid paymentId, CancellationToken ct)
    {
        return await paymentService.GetPaymentByIdAsync(paymentId);
    }
}