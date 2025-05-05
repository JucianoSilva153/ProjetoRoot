using FastEndpoints;
using Root.Application.DTOs.PackageDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PackageEndpoints;

public class ListPackageByIdEndpoint(PackageService packageService) : Endpoint<Guid, ListPackageDto?>
{
    public override void Configure()
    {
        Get("/packages/{packageId:guid}");
        Tags("Packages");
        AllowAnonymous();
    }

    public override async Task<ListPackageDto?> ExecuteAsync(Guid packageId, CancellationToken ct)
    {
        return await packageService.GetPackageByIdAsync(packageId);
    }
}