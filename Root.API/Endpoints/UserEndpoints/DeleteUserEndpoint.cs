using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.UserEndpoints;

public class DeleteUserEndpoint(UserService userService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/users/{userId:guid}");
        Tags("Users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid userId, CancellationToken ct)
    {
        var success = await userService.DeleteUserAsync(userId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}