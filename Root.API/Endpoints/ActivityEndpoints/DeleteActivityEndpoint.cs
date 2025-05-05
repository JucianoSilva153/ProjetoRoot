using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.ActivityEndpoints;

public class DeleteActivityEndpoint(ActivityService activityService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/activities/{activityId:guid}");
        Tags("Activities");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid activityId, CancellationToken ct)
    {
        var success = await activityService.DeleteActivityAsync(activityId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}