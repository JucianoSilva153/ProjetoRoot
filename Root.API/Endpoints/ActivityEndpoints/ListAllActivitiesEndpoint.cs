using FastEndpoints;
using Root.Application.DTOs.ActivityDto;
using Root.Application.Services;

namespace Root.API.Endpoints.ActivityEndpoints;

public class ListAllActivitiesEndpoint(ActivityService activityService) : EndpointWithoutRequest<List<ListActivityDto>>
{
    public override void Configure()
    {
        Get("/activities");
        Description(x => x.WithTags("Activities"));
        AllowAnonymous();
    }

    public override async Task<List<ListActivityDto>> ExecuteAsync(CancellationToken ct)
    {
        return await activityService.ListAllActivitiesAsync();
    }
}