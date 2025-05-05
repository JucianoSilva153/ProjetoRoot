using FastEndpoints;
using Root.Application.DTOs.UserDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.UserEndpoints;

public class ListAllUsersEndpoint(UserService userService) : EndpointWithoutRequest<List<ListUserDto>>
{
    public override void Configure()
    {
        Get("/users");
        Tags("Users");
        AllowAnonymous();
    }

    public override async Task<List<ListUserDto>> ExecuteAsync(CancellationToken ct)
    {
        return await userService.ListAllUsersAsync();
    }
}