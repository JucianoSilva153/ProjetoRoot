using FastEndpoints;
using Root.Application.DTOs.AdminDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.AdminEndpoints;

public class CreateAdministratorEndpoint(AdministratorService administratorService) : Endpoint<CreateAdministratorDto>
{
    public override void Configure()
    {
        Post("/administrators");
        Tags("Administrators");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateAdministratorDto req, CancellationToken ct)
    {
        var success = await administratorService.CreateAdministratorAsync(req);
        if (success)
            await SendAsync("Administrador criado com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}