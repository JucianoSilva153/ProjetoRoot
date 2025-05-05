using FastEndpoints;
using Root.Application.DTOs.PaymentDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PaymentEndpoints;

public class CreatePaymentEndpoint(PaymentService paymentService) : Endpoint<CreatePaymentDto>
{
    public override void Configure()
    {
        Post("/payments");
        Description(x => x.WithTags("Payments"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePaymentDto req, CancellationToken ct)
    {
        var success = await paymentService.CreatePaymentAsync(req);
        if (success)
            await SendAsync("Pagamento criado com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}