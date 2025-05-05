using FastEndpoints;
using Root.Application.DTOs.CategoryDtos;
using Root.Application.Services;

namespace Root.API.Endpoints.CategoryEndpoints;

public class ListAllCategoriesEndpoint(CategoryService categoryService) : EndpointWithoutRequest<List<ListCategoryDto>>
{
    public override void Configure()
    {
        Get("/categories");
        Description(x => x.WithTags("Categories"));
        AllowAnonymous();
    }

    public override async Task<List<ListCategoryDto>> ExecuteAsync(CancellationToken ct)
    {
        return await categoryService.ListAllCategoriesAsync();
    }
}