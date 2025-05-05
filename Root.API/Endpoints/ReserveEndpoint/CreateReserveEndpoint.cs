using FastEndpoints;
using Root.Application.DTOs.ReserveDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ReserveEndpoints;

public class CreateReserveEndpoint(ReserveService reserveService) : Endpoint<CreateReserveDto>
{
    public override void Configure()
    {
        Post("/reserves");
        Description(x => x.WithTags("Reserves"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateReserveDto req, CancellationToken ct)
    {
        var success = await reserveService.CreateReserveAsync(req);
        if (success)
            await SendAsync("Reserva criada com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}