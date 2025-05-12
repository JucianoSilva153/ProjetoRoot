using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Root.Application.DTOs.UserDtos;
using Root.Application.Services;

public class CreateUserEndpoint(UserService userService) : Endpoint<CreateUserDto>
{
    public override void Configure()
    {
        Post("/users");
        Description(x => x.WithTags("Users"));
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(CreateUserDto req, CancellationToken ct)
    {
        var success = await userService.CreateUserAsync(req);
        if (success)
            await SendAsync("Usuário criado com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}