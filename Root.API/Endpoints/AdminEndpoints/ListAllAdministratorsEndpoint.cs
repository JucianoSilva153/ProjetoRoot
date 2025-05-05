using FastEndpoints;
using Root.Application.DTOs.AdminDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.AdminEndpoints;

public class ListAllAdministratorsEndpoint(AdministratorService administratorService) : EndpointWithoutRequest<List<ListAdminDto>>
{
    public override void Configure()
    {
        Get("/administrators");
        Tags("Administrators");
        AllowAnonymous();
    }

    public override async Task<List<ListAdminDto>> ExecuteAsync(CancellationToken ct)
    {
        return await administratorService.ListAllAdministratorsAsync();
    }
}