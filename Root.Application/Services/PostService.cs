using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Root.Application.DTOs.PostDtos;
using Root.Domain.Entities.Blog;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class PostService(IPostRepository postRepository,ICategoryRepository categoryRepository,  IHttpContextAccessor contextAccessor)
{
    public Guid? GetCurrentUserId()
    {
        var currentUser = contextAccessor.HttpContext?.User;
        var userStringId = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Guid.Parse(userStringId!);
    }

    public string GetCurrentUserRole()
    {
        var currentUser = contextAccessor.HttpContext?.User;
        var userrole = currentUser?.FindFirst(ClaimTypes.Role)?.Value;

        return userrole ?? "";
    }
    
    public async Task<bool> CreatePostAsync(CreatePostDto dto)
    {
        try
        {
            var userId = GetCurrentUserId();
            if (userId is null)
                return false;

            var categories = await categoryRepository.GetAllAsync();
            var selectedCategories = categories
                .Where(c => dto.CategoryIds.Contains(c.Id))
                .ToList();

            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                Image = dto.Image,
                Categories = selectedCategories,
                ModifiedBy = userId
            };

            return await postRepository.CreateAsync(post);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao criar post: " + ex.Message);
        }

        return false;
    }

    public async Task<List<ListPostDto>> ListAllPostsAsync()
    {
        try
        {
            var posts = await postRepository.GetAllAsync();

            var userRole = GetCurrentUserRole();
            if ( userRole != "Administrador" && !string.IsNullOrEmpty(GetCurrentUserRole()))
            {
                posts = posts.Where(p => p.ModifiedBy == GetCurrentUserId());
            }
            
            return posts.Select(p => new ListPostDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Image = p.Image,
                CategoryNames = p.Categories.Select(c => c.Title).ToList()
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar posts: " + ex.Message);
        }

        return [];
    }

    public async Task<ListPostDto?> GetPostByIdAsync(Guid id)
    {
        try
        {
            var post = await postRepository.GetByIdAsync(id);
            if (post is null)
                return null;

            return new ListPostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Image = post.Image,
                CategoryNames = post.Categories.Select(c => c.Title).ToList()
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar post: " + ex.Message);
        }

        return null;
    }

    public async Task<bool> UpdatePostAsync(UpdatePostDto dto)
    {
        try
        {
            var post = await postRepository.GetByIdAsync(dto.Id);
            if (post is null)
                return false;

            post.Title = dto.Title ?? post.Title;
            post.Content = dto.Content ?? post.Content;
            post.Image = dto.Image ?? post.Image;

            if (dto.CategoryIds is not null)
            {
                post.Categories = dto.CategoryIds.Select(id => new Category { Id = id }).ToList();
            }

            return await postRepository.UpdateAsync(post);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar post: " + ex.Message);
        }

        return false;
    }

    public async Task<bool> DeletePostAsync(Guid id)
    {
        try
        {
            return await postRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao deletar post: " + ex.Message);
        }

        return false;
    }
}
