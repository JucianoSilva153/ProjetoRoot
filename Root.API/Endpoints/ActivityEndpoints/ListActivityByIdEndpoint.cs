using FastEndpoints;
using Root.Application.DTOs.ActivityDto;
using Root.Application.Services;

namespace Root.API.Endpoints.ActivityEndpoints;

public class ListActivityByIdEndpoint(ActivityService activityService) : Endpoint<Guid, ListActivityDto?>
{
    public override void Configure()
    {
        Get("/activities/{activityId:guid}");
        Tags("Activities");
        AllowAnonymous();
    }

    public override async Task<ListActivityDto?> ExecuteAsync(Guid activityId, CancellationToken ct)
    {
        return await activityService.ListActivityByIdAsync(activityId);
    }
}