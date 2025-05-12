using FastEndpoints;
using Root.Application.DTOs.UserDtos;
using Root.Application.Services;
using Root.Domain.Enums;
using Root.Infrastructure.Service;

namespace Root.API.Endpoints.UserEndpoints;

public class LoginUserEndpoint(UserService userService, JwtTokenService tokenService)
    : Endpoint<LoginUserDto, LoginListUserDto?>
{
    public override void Configure()
    {
        Post("/users/login");
        Description(x => x.WithTags("Users"));
        AllowAnonymous();
    }

    public override async Task<LoginListUserDto?> ExecuteAsync(LoginUserDto loginDto, CancellationToken ct)
    {
        var user = await userService.LoginAsync(loginDto);
        if (user is null)
        {
            await SendUnauthorizedAsync(ct);
            return null;
        }

        var token = tokenService.GenerateToken(user.Id, user.UserName, user.Type.ToFriendlyString());
        if (string.IsNullOrEmpty(token))
        {
            await SendUnauthorizedAsync(ct);
            return null;
        }

        var specificUserId = await userService.GetUserSpecificTypeIdAsync(user.Id);
        if (specificUserId is null)
        {
            await SendErrorsAsync(500, ct);
            return null;
        }
        
        return new LoginListUserDto
        {
            Token = token,
            User = user,
            UserTypeId = specificUserId ?? Guid.Empty
        };
    }
}