using Root.Domain.Enums;

namespace Root.Application.DTOs.PackageDtos;

public class ListPackageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PackageType Type { get; set; }

    public List<string> ActivityNames { get; set; } // ou uma lista de DTOs de Activity
}
