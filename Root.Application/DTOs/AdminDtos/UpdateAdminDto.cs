using Root.Domain.Enums;

namespace Root.Application.DTOs.AdminDtos;

public class UpdateAdminDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public AdministratorRole? Role { get; set; }
    public List<AdministratorAcess>? AcessLeves { get; set; }
}