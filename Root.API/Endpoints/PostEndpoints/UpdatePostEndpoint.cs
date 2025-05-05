using FastEndpoints;
using Root.Application.DTOs.PostDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PostEndpoints;

public class UpdatePostEndpoint(PostService postService) : Endpoint<UpdatePostDto>
{
    public override void Configure()
    {
        Put("/posts");
        Tags("Posts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdatePostDto req, CancellationToken ct)
    {
        var success = await postService.UpdatePostAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}