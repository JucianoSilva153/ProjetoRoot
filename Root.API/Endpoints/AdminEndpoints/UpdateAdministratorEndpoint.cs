using FastEndpoints;
using Root.Application.DTOs.AdminDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.AdminEndpoints;

public class UpdateAdministratorEndpoint(AdministratorService administratorService) : Endpoint<UpdateAdminDto>
{
    public override void Configure()
    {
        Put("/administrators");
        Description(x => x.WithTags("Administrators"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateAdminDto req, CancellationToken ct)
    {
        var success = await administratorService.UpdateAdministratorAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}