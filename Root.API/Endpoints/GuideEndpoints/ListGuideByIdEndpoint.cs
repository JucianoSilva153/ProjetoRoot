using FastEndpoints;
using Root.Application.DTOs;
using Root.Application.DTOs.GuideDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.GuideEndpoints;

public class ListGuideByIdEndpoint(GuideService guideService) : EndpointWithoutRequest<ListGuidesDto?>
{
    public override void Configure()
    {
        Get("/guides/{GuideId:guid}");
        AllowAnonymous();
    }

    public override async Task<ListGuidesDto?> ExecuteAsync(CancellationToken ct)
    {
        var guideIdStr = Route<string>("GuideId");
        var guideId = Guid.Parse(guideIdStr);
        return await guideService.GetGuideByIdAsync(guideId);
    }
}


public class GuideIdRequest
{
    public Guid GuideId { get; set; }
}

