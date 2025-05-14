using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Root.Application.DTOs.PaymentDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PaymentEndpoints;

public class ListAllPaymentsEndpoint(PaymentService paymentService) : EndpointWithoutRequest<List<ListPaymentDto>>
{
    public override void Configure()
    {
        Get("/payments");
        Description(x => x.WithTags("Payments"));
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task<List<ListPaymentDto>> ExecuteAsync(CancellationToken ct)
    {
        return await paymentService.ListAllPaymentsAsync();
    }
}