using FastEndpoints;
using Root.Application.DTOs.ReserveDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ReserveEndpoints;

public class UpdateReserveEndpoint(ReserveService reserveService) : Endpoint<UpdateReserveDto>
{
    public override void Configure()
    {
        Put("/reserves");
        Tags("Reserves");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateReserveDto req, CancellationToken ct)
    {
        var success = await reserveService.UpdateReserveAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}