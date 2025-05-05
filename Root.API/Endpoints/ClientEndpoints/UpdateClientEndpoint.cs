using FastEndpoints;
using Root.Application.DTOs.ClientDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.ClientEndpoints;

public class UpdateClientEndpoint(ClientService clientService) : Endpoint<UpdateClientDto>
{
    public override void Configure()
    {
        Put("/clients");
        Tags("Clients");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateClientDto req, CancellationToken ct)
    {
        var success = await clientService.UpdateClientAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}