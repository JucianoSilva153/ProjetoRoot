using FastEndpoints;
using Root.Application.DTOs.PackageDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PackageEndpoints;

public class ListPackageByIdEndpoint(PackageService packageService) : EndpointWithoutRequest<ListPackageDto?>
{
    public override void Configure()
    {
        Get("/packages/{packageId:guid}");
        Description(x => x.WithTags("Packages"));
        AllowAnonymous();
    }

    public override async Task<ListPackageDto?> ExecuteAsync( CancellationToken ct)
    {
        var packIdStr = Route<string>("packageId");
        var packId = Guid.Parse(packIdStr);
        return await packageService.GetPackageByIdAsync(packId);
    }
}