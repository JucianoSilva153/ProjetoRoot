using FastEndpoints;
using Root.Application.DTOs.PostDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.PostEndpoints;

public class ListAllPostsEndpoint(PostService postService) : EndpointWithoutRequest<List<ListPostDto>>
{
    public override void Configure()
    {
        Get("/posts");
        Description(x => x.WithTags("Posts"));
        AllowAnonymous();
    }

    public override async Task<List<ListPostDto>> ExecuteAsync(CancellationToken ct)
    {
        return await postService.ListAllPostsAsync();
    }
}