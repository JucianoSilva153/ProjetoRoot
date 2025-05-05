using FastEndpoints;
using Root.Application.DTOs.PackageDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PackageEndpoints;

public class CreatePackageEndpoint(PackageService packageService) : Endpoint<CreatePackageDto>
{
    public override void Configure()
    {
        Post("/packages");
        Tags("Packages");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePackageDto req, CancellationToken ct)
    {
        var success = await packageService.CreatePackageAsync(req);
        if (success)
            await SendAsync("Pacote criado com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}