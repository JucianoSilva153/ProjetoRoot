using FastEndpoints;
using Root.Application.DTOs.ReserveDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ReserveEndpoints;

public class ListReserveByIdEndpoint(ReserveService reserveService) : EndpointWithoutRequest<ListReserveDto>
{
    public override void Configure()
    {
        Get("/reserves/{reserveId:guid}");
        Description(x => x.WithTags("Reserves"));
        AllowAnonymous();
    }

    public override async Task<ListReserveDto?> ExecuteAsync(CancellationToken ct)
    {
        var reserveIdStr = Route<string>("reserveId");
        var reserveId = Guid.Parse(reserveIdStr);
        return await reserveService.GetReserveByIdAsync(reserveId);
    }
}