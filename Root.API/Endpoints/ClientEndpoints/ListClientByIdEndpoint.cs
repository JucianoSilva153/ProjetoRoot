using FastEndpoints;
using Root.Application.DTOs.ClientDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ClientEndpoints;

public class ListClientByIdEndpoint(ClientService clientService) : Endpoint<Guid, ListClientsDto?>
{
    public override void Configure()
    {
        Get("/clients/{clientId:guid}");
        Tags("Clients");
        AllowAnonymous();
    }

    public override async Task<ListClientsDto?> ExecuteAsync(Guid clientId, CancellationToken ct)
    {
        return await clientService.GetClientByIdAsync(clientId);
    }
}