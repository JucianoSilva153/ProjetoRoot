using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.PackageEndpoints;

public class DeletePackageEndpoint(PackageService packageService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/packages/{packageId:guid}");
        Description(x => x.WithTags("Packages"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid packageId, CancellationToken ct)
    {
        var success = await packageService.DeletePackageAsync(packageId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}