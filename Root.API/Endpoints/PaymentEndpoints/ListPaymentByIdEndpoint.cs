using FastEndpoints;
using Root.Application.DTOs.PaymentDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PaymentEndpoints;

public class ListPaymentByIdEndpoint(PaymentService paymentService) : EndpointWithoutRequest<ListPaymentDto?>
{
    public override void Configure()
    {
        Get("/payments/{paymentId:guid}");
        Description(x => x.WithTags("Payments"));
        AllowAnonymous();
    }

    public override async Task<ListPaymentDto?> ExecuteAsync(CancellationToken ct)
    {
        var paymentIdStr = Route<string>("paymentId");
        var paymentId = Guid.Parse(paymentIdStr);
        return await paymentService.GetPaymentByIdAsync(paymentId);
    }
}