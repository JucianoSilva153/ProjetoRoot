using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.GuideEndpoints;

public class DeleteGuideEndpoint(GuideService guideService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/guides/{guideId:guid}");
        Tags("Guides");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid guideId, CancellationToken ct)
    {
        var success = await guideService.DeleteGuideAsync(guideId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}