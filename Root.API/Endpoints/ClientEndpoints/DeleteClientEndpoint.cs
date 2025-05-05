using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.ClientEndpoints;

public class DeleteClientEndpoint(ClientService clientService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/clients/{clientId:guid}");
        Tags("Clients");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid clientId, CancellationToken ct)
    {
        var success = await clientService.DeleteClientAsync(clientId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}