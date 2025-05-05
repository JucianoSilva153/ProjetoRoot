using FastEndpoints;
using Root.Application.DTOs.ReserveDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ReserveEndpoints;

public class ListReserveByIdEndpoint(ReserveService reserveService) : Endpoint<Guid, ListReserveDto>
{
    public override void Configure()
    {
        Get("/reserves/{reserveId:guid}");
        Description(x => x.WithTags("Reserves"));
        AllowAnonymous();
    }

    public override async Task<ListReserveDto?> ExecuteAsync(Guid reserveId, CancellationToken ct)
    {
        return await reserveService.GetReserveByIdAsync(reserveId);
    }
}