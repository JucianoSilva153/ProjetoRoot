using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.PostEndpoints;

public class DeletePostEndpoint(PostService postService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/posts/{postId:guid}");
        Description(x => x.WithTags("Posts"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid postId, CancellationToken ct)
    {
        var success = await postService.DeletePostAsync(postId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}