using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.PaymentEndpoints;

public class DeletePaymentEndpoint(PaymentService paymentService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/payments/{paymentId:guid}");
        Description(x => x.WithTags("Payments"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid paymentId, CancellationToken ct)
    {
        var success = await paymentService.DeletePaymentAsync(paymentId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}