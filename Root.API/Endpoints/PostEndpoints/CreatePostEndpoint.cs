using FastEndpoints;
using Root.Application.DTOs.PostDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PostEndpoints;

public class CreatePostEndpoint(PostService postService) : Endpoint<CreatePostDto>
{
    public override void Configure()
    {
        Post("/posts");
        Tags("Posts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePostDto req, CancellationToken ct)
    {
        var success = await postService.CreatePostAsync(req);
        if (success)
            await SendAsync("Publicação criada com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}