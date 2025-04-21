using Root.Domain.Enums;

namespace Root.Domain.Entities.Packages;

public class Activity : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public uint DurationTime { get; set; }
    public decimal Price { get; set; }
    public ActivityType Type { get; set; }

    public ICollection<Package> Packages { get; set; }
}