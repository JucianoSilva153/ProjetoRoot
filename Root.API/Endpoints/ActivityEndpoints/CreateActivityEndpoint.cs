using FastEndpoints;
using Root.Application.DTOs.ActivityDto;
using Root.Application.Services;

namespace Root.API.Endpoints.ActivityEndpoints;

public class CreateActivityEndpoint(ActivityService activityService) : Endpoint<CreateActivityDto>
{
    public override void Configure()
    {
        Post("/activities");
        Description(x => x.WithTags("Activities"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateActivityDto req, CancellationToken ct)
    {
        var success = await activityService.CreateActivityAsync(req);
        if (success)
            await SendAsync("Atividade criada com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}