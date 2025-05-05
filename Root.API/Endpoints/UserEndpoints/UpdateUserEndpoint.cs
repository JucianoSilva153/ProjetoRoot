using FastEndpoints;
using Root.Application.DTOs.UserDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.UserEndpoints;

public class UpdateUserEndpoint(UserService userService) : Endpoint<UpdateUserDto>
{
    public override void Configure()
    {
        Put("/users");
        Tags("Users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateUserDto req, CancellationToken ct)
    {
        var success = await userService.UpdateUserAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}