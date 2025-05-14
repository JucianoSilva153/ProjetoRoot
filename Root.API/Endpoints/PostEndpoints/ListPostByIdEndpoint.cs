using FastEndpoints;
using Root.Application.DTOs.PostDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PostEndpoints;

public class ListPostByIdEndpoint(PostService postService) : EndpointWithoutRequest<ListPostDto?>
{
    public override void Configure()
    {
        Get("/posts/{postId:guid}");
        Description(x => x.WithTags("Posts"));
        AllowAnonymous();
    }

    public override async Task<ListPostDto?> ExecuteAsync(CancellationToken ct)
    {
        var postIdStr = Route<string>("postId");
        var postId = Guid.Parse(postIdStr);
        return await postService.GetPostByIdAsync(postId);
    }
}