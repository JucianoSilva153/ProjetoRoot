using Root.Application.DTOs.GuideDtos;
using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class GuideService(IGuideRepository guideRepository)
{
    public async Task<bool> CreateGuideAsync(CreateGuideDto dto)
    {
        try
        {
            var guide = new Guide
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Idioms = dto.Idioms,
                Description = dto.Description,
                Location = dto.Location,
                UserId = dto.UserId,
                Image = dto.Image
            };

            return await guideRepository.CreateAsync(guide);
        }
        catch (Exception ex)
        {   
            Console.WriteLine("Erro ao criar guia: " + ex.Message);
        }

        return false;
    }

    public async Task<List<ListGuidesDto>> ListAllGuidesAsync()
    {
        try
        {
            var guides = await guideRepository.GetAllAsync();
            return guides.Select(guide => new ListGuidesDto
            {
                Id = guide.Id,
                Name = guide.Name,
                Surname = guide.Surname,
                Idioms = guide.Idioms,
                Description = guide.Description,
                Location = guide.Location,
                UserId = guide.UserId
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar guias: " + ex.Message);
        }

        return [];
    }

    public async Task<ListGuidesDto?> GetGuideByIdAsync(Guid id)
    {
        try
        {
            var guide = await guideRepository.GetByIdAsync(id);
            if (guide is null)
                return null;

            return new ListGuidesDto
            {
                Id = guide.Id,
                Name = guide.Name,
                Surname = guide.Surname,
                Idioms = guide.Idioms,
                Description = guide.Description,
                Location = guide.Location,
                UserId = guide.UserId,
                Image = guide.Image,
                UserName = guide.User.UserName
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar guia: " + ex.Message);
        }

        return null;
    }

    public async Task<bool> UpdateGuideAsync(UpdateGuideDto dto)
    {
        try
        {
            var guide = await guideRepository.GetByIdAsync(dto.Id);
            if (guide is null)
                return false;

            guide.Name = dto.Name ?? guide.Name;
            guide.Surname = dto.Surname ?? guide.Surname;
            guide.Idioms = dto.Idioms ?? guide.Idioms;
            guide.Description = dto.Description ?? guide.Description;
            guide.Location = dto.Location ?? guide.Location;
            guide.Image = dto.Image ?? guide.Image;

            return await guideRepository.UpdateAsync(guide);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar guia: " + ex.Message);
        }

        return false;
    }

    public async Task<bool> DeleteGuideAsync(Guid id)
    {
        try
        {
            return await guideRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao deletar guia: " + ex.Message);
        }

        return false;
    }
}
