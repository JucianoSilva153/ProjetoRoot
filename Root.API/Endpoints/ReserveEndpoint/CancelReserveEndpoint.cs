using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Root.Application.Services;

namespace Root.API.Endpoints.ReserveEndpoints;

public class CancelReserveEndpoint(ReserveService reserveService) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete("/reserves/cancel/{reserveId:guid}");
        Description(x => x.WithTags("Reserves"));
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var reserveId = Route<Guid>("reserveId");

        var success = await reserveService.CancelReserveAsync(reserveId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}
