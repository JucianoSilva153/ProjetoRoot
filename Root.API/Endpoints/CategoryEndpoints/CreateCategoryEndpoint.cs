using FastEndpoints;
using Root.Application.DTOs.CategoryDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.CategoryEndpoints;

public class CreateCategoryEndpoint(CategoryService categoryService) : Endpoint<CreateCategoryDto>
{
    public override void Configure()
    {
        Post("/categories");
        Tags("Categories");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCategoryDto req, CancellationToken ct)
    {
        var success = await categoryService.CreateCategoryAsync(req);
        if (success)
            await SendAsync("Categoria criada com sucesso!", 201, ct);
        else
            await SendErrorsAsync(500, ct);
    }
}