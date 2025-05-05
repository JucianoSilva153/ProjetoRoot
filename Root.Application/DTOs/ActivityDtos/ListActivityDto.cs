using Root.Domain.Enums;

namespace Root.Application.DTOs.ActivityDto;

public class ListActivityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public uint DurationTime { get; set; }
    public decimal Price { get; set; }
    public ActivityType Type { get; set; }

    public List<string> PackageNames { get; set; } // ou List<Guid> PackageIds se preferir
}
