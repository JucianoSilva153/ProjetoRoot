using Root.Application.DTOs.ActivityDto;
using Root.Domain.Entities.Packages;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class ActivityService(IActivityRepository activityRepository)
{
    public async Task<bool> CreateActivityAsync(CreateActivityDto dto)
    {
        try
        {
            var activity = new Activity
            {
                Name = dto.Name,
                Description = dto.Description,
                DurationTime = dto.DurationTime,
                Price = dto.Price,
                Type = dto.Type
            };

            return await activityRepository.CreateAsync(activity);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar criar nova Atividade!");
        }

        return false;
    }

    public async Task<List<ListActivityDto>> ListAllActivitiesAsync()
    {
        try
        {
            var activities = await activityRepository.GetAllAsync();
            return activities.Select(a => new ListActivityDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                DurationTime = a.DurationTime,
                Price = a.Price,
                Type = a.Type
            }).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao tentar listar Atividades!");
        }

        return new();
    }

    public async Task<ListActivityDto?> ListActivityByIdAsync(Guid id)
    {
        try
        {
            var activity = await activityRepository.GetByIdAsync(id);
            if (activity is null)
                return null;

            return new ListActivityDto
            {
                Id = activity.Id,
                Name = activity.Name,
                Description = activity.Description,
                DurationTime = activity.DurationTime,
                Price = activity.Price,
                Type = activity.Type
            };
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao procurar Atividade!");
        }

        return null;
    }

    public async Task<bool> UpdateActivityAsync(UpdateActivityDto dto)
    {
        try
        {
            var activity = await activityRepository.GetByIdAsync(dto.Id);
            if (activity is null)
                return false;

            activity.Name = dto.Name ?? activity.Name;
            activity.Description = dto.Description ?? activity.Description;
            activity.DurationTime = dto.DurationTime ?? activity.DurationTime;
            activity.Price = dto.Price ?? activity.Price;
            activity.Type = dto.Type ?? activity.Type;

            return await activityRepository.UpdateAsync(activity);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao atualizar Atividade!");
        }

        return false;
    }

    public async Task<bool> DeleteActivityAsync(Guid id)
    {
        try
        {
            return await activityRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao eliminar Atividade!");
        }

        return false;
    }
}
