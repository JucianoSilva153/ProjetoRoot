using Root.Domain.Enums;

namespace Root.Application.DTOs.ActivityDto;

public class UpdateActivityDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public uint? DurationTime { get; set; }
    public decimal? Price { get; set; }
    public ActivityType? Type { get; set; }

    public List<Guid>? PackageIds { get; set; }
}
