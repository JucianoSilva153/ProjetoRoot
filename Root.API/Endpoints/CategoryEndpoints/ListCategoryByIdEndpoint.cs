using FastEndpoints;
using Root.Application.DTOs.CategoryDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.CategoryEndpoints;

public class ListCategoryByIdEndpoint(CategoryService categoryService) : EndpointWithoutRequest<ListCategoryDto?>
{
    public override void Configure()
    {
        Get("/categories/{categoryId:guid}");
        Description(x => x.WithTags("Categories"));
        AllowAnonymous();
    }

    public override async Task<ListCategoryDto?> ExecuteAsync(CancellationToken ct)
    {
        var categoryIdStr = Route<string>("categoryId");
        var categoryId = Guid.Parse(categoryIdStr);
        return await categoryService.ListCategoryByIdAsync(categoryId);
    }
}