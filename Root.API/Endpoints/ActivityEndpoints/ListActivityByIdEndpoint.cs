using FastEndpoints;
using Root.Application.DTOs.ActivityDto;
using Root.Application.Services;

namespace Root.API.Endpoints.ActivityEndpoints;

public class ListActivityByIdEndpoint(ActivityService activityService) : EndpointWithoutRequest<ListActivityDto?>
{
    public override void Configure()
    {
        Get("/activities/{activityId:guid}");
        Description(x => x.WithTags("Activities"));
        AllowAnonymous();
    }

    public override async Task<ListActivityDto?> ExecuteAsync(CancellationToken ct)
    {
        var activityIdStr = Route<string>("activityId");
        var activityId = Guid.Parse(activityIdStr);
        return await activityService.ListActivityByIdAsync(activityId);
    }
}