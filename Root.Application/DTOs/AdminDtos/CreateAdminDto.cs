using Root.Domain.Enums;

namespace Root.Application.DTOs.AdminDtos;

public class CreateAdministratorDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public AdministratorRole? Role { get; set; }
    public List<Guid> AcessLevesIds { get; set; } // Apenas os IDs dos acessos
    public Guid UserId { get; set; }
}
