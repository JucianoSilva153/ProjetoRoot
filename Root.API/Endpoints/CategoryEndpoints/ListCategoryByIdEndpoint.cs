using FastEndpoints;
using Root.Application.DTOs.CategoryDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.CategoryEndpoints;

public class ListCategoryByIdEndpoint(CategoryService categoryService) : Endpoint<Guid, ListCategoryDto?>
{
    public override void Configure()
    {
        Get("/categories/{categoryId:guid}");
        Description(x => x.WithTags("Categories"));
        AllowAnonymous();
    }

    public override async Task<ListCategoryDto?> ExecuteAsync(Guid categoryId, CancellationToken ct)
    {
        return await categoryService.ListCategoryByIdAsync(categoryId);
    }
}