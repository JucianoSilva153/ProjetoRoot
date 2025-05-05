using FastEndpoints;
using Root.Application.DTOs.GuideDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.GuideEndpoints;

public class ListGuideByIdEndpoint(GuideService guideService) : Endpoint<Guid, ListGuidesDto?>
{
    public override void Configure()
    {
        Get("/guides/{guideId:guid}");
        Description(x => x.WithTags("Guides"));
        AllowAnonymous();
    }

    public override async Task<ListGuidesDto?> ExecuteAsync(Guid guideId, CancellationToken ct)
    {
        return await guideService.GetGuideByIdAsync(guideId);
    }
}