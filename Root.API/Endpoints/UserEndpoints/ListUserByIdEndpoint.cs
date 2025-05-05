using FastEndpoints;
using Root.Application.DTOs.UserDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.UserEndpoints;

public class ListUserByIdEndpoint(UserService userService) : Endpoint<Guid, ListUserDto>
{
    public override void Configure()
    {
        Get("/users/{userId:guid}");
        Tags("Users");
        AllowAnonymous();
    }

    public override async Task<ListUserDto?> ExecuteAsync(Guid userId, CancellationToken ct)
    {
        return await userService.ListUserAsync(userId);
    }
}