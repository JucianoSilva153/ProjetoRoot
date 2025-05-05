using FastEndpoints;
using Root.Application.DTOs.PackageDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PackageEndpoints;

public class UpdatePackageEndpoint(PackageService packageService) : Endpoint<UpdatePackageDto>
{
    public override void Configure()
    {
        Put("/packages");
        Description(x => x.WithTags("Packages"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdatePackageDto req, CancellationToken ct)
    {
        var success = await packageService.UpdatePackageAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}