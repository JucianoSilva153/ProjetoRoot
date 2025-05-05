using FastEndpoints;
using Root.Application.DTOs.PaymentDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PaymentEndpoints;

public class UpdatePaymentEndpoint(PaymentService paymentService) : Endpoint<UpdatePaymentDto>
{
    public override void Configure()
    {
        Put("/payments");
        Tags("Payments");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdatePaymentDto req, CancellationToken ct)
    {
        var success = await paymentService.UpdatePaymentAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}