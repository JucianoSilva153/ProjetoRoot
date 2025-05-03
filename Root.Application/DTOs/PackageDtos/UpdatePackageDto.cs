using Root.Domain.Enums;

namespace Root.Application.DTOs.PackageDtos;

public class UpdatePackageDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public PackageType? Type { get; set; }

    public List<Guid>? ActivityIds { get; set; }
}
