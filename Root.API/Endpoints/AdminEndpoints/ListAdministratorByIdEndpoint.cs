using FastEndpoints;
using Root.Application.DTOs;
using Root.Application.DTOs.AdminDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.AdminEndpoints;

public class ListAdministratorByIdEndpoint(AdministratorService administratorService) : EndpointWithoutRequest<ListAdminDto?>
{
    public override void Configure()
    {
        Get("/administrators/{AdminId:guid}");
        Description(x => x.WithTags("Administrators"));
        AllowAnonymous();
    }

    public override async Task<ListAdminDto?> ExecuteAsync(CancellationToken ct)
    {
        var adminIdStr = Route<string>("AdminId");
        var adminId = Guid.Parse(adminIdStr);
        return await administratorService.GetAdministratorByIdAsync(adminId);
    }
}