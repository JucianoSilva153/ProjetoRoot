using FastEndpoints;
using Root.Application.DTOs.ClientDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ClientEndpoints;

public class ListAllClientsEndpoint(ClientService clientService) : EndpointWithoutRequest<List<ListClientsDto>>
{
    public override void Configure()
    {
        Get("/clients");
        Tags("Clients");
        AllowAnonymous();
    }

    public override async Task<List<ListClientsDto>> ExecuteAsync(CancellationToken ct)
    {
        return await clientService.ListAllClientsAsync();
    }
}