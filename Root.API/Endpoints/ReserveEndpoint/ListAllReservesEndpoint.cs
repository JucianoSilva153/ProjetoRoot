using FastEndpoints;
using Root.Application.DTOs.ReserveDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ReserveEndpoints;

public class ListAllReservesEndpoint(ReserveService reserveService) : EndpointWithoutRequest<List<ListReserveDto>>
{
    public override void Configure()
    {
        Get("/reserves");
        Tags("Reserves");
        AllowAnonymous();
    }

    public override async Task<List<ListReserveDto>> ExecuteAsync(CancellationToken ct)
    {
        return await reserveService.ListAllReservesAsync();
    }
}