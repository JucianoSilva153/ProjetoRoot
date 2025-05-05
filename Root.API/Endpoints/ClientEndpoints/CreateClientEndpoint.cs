using FastEndpoints;
using Root.Application.DTOs.ClientDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ClientEndpoints;

public class CreateClientEndpoint(ClientService clientService) : Endpoint<CreateClientDto>
{
    public override void Configure()
    {
        Post("/clients");
        Tags("Clients");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateClientDto req, CancellationToken ct)
    {
        var success = await clientService.CreateClientAsync(req);
        if (success)
            await SendAsync("Cliente criado com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}