using FastEndpoints;
using Root.Application.DTOs.UserDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.UserEndpoints;

public class ListUserByIdEndpoint(UserService userService) : EndpointWithoutRequest<ListUserDto?>
{
    public override void Configure()
    {
        Get("/users/{userId:guid}");
        Description(x => x.WithTags("Users"));
        AllowAnonymous();
    }

    public override async Task<ListUserDto?> ExecuteAsync(CancellationToken ct)
    {
        var userIdStr = Route<string>("userId");
        var userId = Guid.Parse(userIdStr);
        return await userService.ListUserAsync(userId);
    }
}