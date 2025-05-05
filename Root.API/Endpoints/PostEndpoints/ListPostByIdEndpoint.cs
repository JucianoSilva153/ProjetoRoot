using FastEndpoints;
using Root.Application.DTOs.PostDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PostEndpoints;

public class ListPostByIdEndpoint(PostService postService) : Endpoint<Guid, ListPostDto?>
{
    public override void Configure()
    {
        Get("/posts/{postId:guid}");
        Description(x => x.WithTags("Posts"));
        AllowAnonymous();
    }

    public override async Task<ListPostDto?> ExecuteAsync(Guid postId, CancellationToken ct)
    {
        return await postService.GetPostByIdAsync(postId);
    }
}