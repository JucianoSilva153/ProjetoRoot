using Root.Domain.Enums;

namespace Root.Domain.Entities.Packages;

public class Package : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public PackageType Type { get; set; }

    public ICollection<Activity> Activities { get; set; }
}