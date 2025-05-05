using Root.Application.DTOs.CategoryDtos;
using Root.Domain.Entities.Blog;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository)
{
    public async Task<bool> CreateCategoryAsync(CreateCategoryDto dto)
    {
        try
        {
            var category = new Category
            {
                Title = dto.Title
            };
            return await categoryRepository.CreateAsync(category);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar nova Categoria!");
        }

        return false;
    }

    public async Task<List<ListCategoryDto>> ListAllCategoriesAsync()
    {
        try
        {
            var categories = await categoryRepository.GetAllAsync();
            return categories.Select(c => new ListCategoryDto
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar listar Categorias!");
        }

        return new();
    }

    public async Task<ListCategoryDto?> ListCategoryByIdAsync(Guid id)
    {
        try
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
                return null;

            return new ListCategoryDto
            {
                Id = category.Id,
                Title = category.Title
            };
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao procurar Categoria!");
        }

        return null;
    }

    public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto dto)
    {
        try
        {
            var category = await categoryRepository.GetByIdAsync(dto.Id);
            if (category is null)
                return false;

            category.Title = dto.Title ?? category.Title;

            return await categoryRepository.UpdateAsync(category);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao atualizar Categoria!");
        }

        return false;
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        try
        {
            return await categoryRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao eliminar Categoria!");
        }

        return false;
    }
}
