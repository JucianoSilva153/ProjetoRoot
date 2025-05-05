using FastEndpoints;
using Root.Application.DTOs.AdminDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.AdminEndpoints;

public class ListAdministratorByIdEndpoint(AdministratorService administratorService) : Endpoint<Guid, ListAdminDto?>
{
    public override void Configure()
    {
        Get("/administrators/{adminId:guid}");
        Description(x => x.WithTags("Administrators"));
        AllowAnonymous();
    }

    public override async Task<ListAdminDto?> ExecuteAsync(Guid adminId, CancellationToken ct)
    {
        return await administratorService.GetAdministratorByIdAsync(adminId);
    }
}