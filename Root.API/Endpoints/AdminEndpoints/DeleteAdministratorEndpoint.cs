using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.AdminEndpoints;

public class DeleteAdministratorEndpoint(AdministratorService administratorService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/administrators/{adminId:guid}");
        Description(x => x.WithTags("Administrators"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid adminId, CancellationToken ct)
    {
        var success = await administratorService.DeleteAdministratorAsync(adminId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}