using FastEndpoints;
using Root.Application.DTOs.PackageDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PackageEndpoints;

public class ListAllPackagesEndpoint(PackageService packageService) : EndpointWithoutRequest<List<ListPackageDto>>
{
    public override void Configure()
    {
        Get("/packages");
        Tags("Packages");
        AllowAnonymous();
    }

    public override async Task<List<ListPackageDto>> ExecuteAsync(CancellationToken ct)
    {
        return await packageService.ListAllPackagesAsync();
    }
}