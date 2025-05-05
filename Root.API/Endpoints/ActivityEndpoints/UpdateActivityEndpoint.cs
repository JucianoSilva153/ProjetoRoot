using FastEndpoints;
using Root.Application.DTOs.ActivityDto;
using Root.Application.Services;

namespace Root.API.Endpoints.ActivityEndpoints;

public class UpdateActivityEndpoint(ActivityService activityService) : Endpoint<UpdateActivityDto>
{
    public override void Configure()
    {
        Put("/activities");
        Description(x => x.WithTags("Activities"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateActivityDto req, CancellationToken ct)
    {
        var success = await activityService.UpdateActivityAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}