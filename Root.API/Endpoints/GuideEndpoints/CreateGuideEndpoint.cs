using FastEndpoints;
using Root.Application.DTOs.GuideDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.GuideEndpoints;

public class CreateGuideEndpoint(GuideService guideService) : Endpoint<CreateGuideDto>
{
    public override void Configure()
    {
        Post("/guides");
        Description(x => x.WithTags("Guides"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateGuideDto req, CancellationToken ct)
    {
        var success = await guideService.CreateGuideAsync(req);
        if (success)
            await SendAsync("Guia criado com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}