using FastEndpoints;
using Root.Application.DTOs.CategoryDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.CategoryEndpoints;

public class UpdateCategoryEndpoint(CategoryService categoryService) : Endpoint<UpdateCategoryDto>
{
    public override void Configure()
    {
        Put("/categories");
        Tags("Categories");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateCategoryDto req, CancellationToken ct)
    {
        var success = await categoryService.UpdateCategoryAsync(req);
        if (success)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}