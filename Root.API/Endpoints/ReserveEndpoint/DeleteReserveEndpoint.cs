using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.ReserveEndpoints;

public class DeleteReserveEndpoint(ReserveService reserveService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/reserves/{reserveId:guid}");
        Tags("Reserves");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid reserveId, CancellationToken ct)
    {
        var success = await reserveService.DeleteReserveAsync(reserveId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}