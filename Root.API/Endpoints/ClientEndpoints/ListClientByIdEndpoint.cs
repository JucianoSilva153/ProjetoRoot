using FastEndpoints;
using Root.Application.DTOs.ClientDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ClientEndpoints;

public class ListClientByIdEndpoint(ClientService clientService) : EndpointWithoutRequest<ListClientsDto?>
{
    public override void Configure()
    {
        Get("/clients/{clientId:guid}");
        Description(x => x.WithTags("Clients"));
        AllowAnonymous();
    }

    public override async Task<ListClientsDto?> ExecuteAsync( CancellationToken ct)
    {
        var clientIdStr = Route<string>("ClientId");
        var clientId = Guid.Parse(clientIdStr);
        return await clientService.GetClientByIdAsync(clientId);
    }
}