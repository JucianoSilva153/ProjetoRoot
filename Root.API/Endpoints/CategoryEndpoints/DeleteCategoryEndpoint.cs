using FastEndpoints;
using Root.Application.Services;

namespace Root.API.Endpoints.CategoryEndpoints;

public class DeleteCategoryEndpoint(CategoryService categoryService) : Endpoint<Guid>
{
    public override void Configure()
    {
        Delete("/categories/{categoryId:guid}");
        Tags("Categories");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid categoryId, CancellationToken ct)
    {
        var success = await categoryService.DeleteCategoryAsync(categoryId);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}