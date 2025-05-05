using FastEndpoints;
using Root.Application.DTOs.GuideDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.GuideEndpoints;

public class ListAllGuidesEndpoint(GuideService guideService) : EndpointWithoutRequest<List<ListGuidesDto>>
{
    public override void Configure()
    {
        Get("/guides");
        Description(x => x.WithTags("Guides"));
        AllowAnonymous();
    }

    public override async Task<List<ListGuidesDto>> ExecuteAsync(CancellationToken ct)
    {
        return await guideService.ListAllGuidesAsync();
    }
}