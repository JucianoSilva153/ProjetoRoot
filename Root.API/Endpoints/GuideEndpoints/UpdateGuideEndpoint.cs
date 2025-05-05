using FastEndpoints;
using Root.Application.DTOs.GuideDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.GuideEndpoints;

public class UpdateGuideEndpoint(GuideService guideService) : Endpoint<UpdateGuideDto>
{
    public override void Configure()
    {
        Put("/guides");
        Tags("Guides");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateGuideDto req, CancellationToken ct)
    {
        var success = await guideService.UpdateGuideAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}