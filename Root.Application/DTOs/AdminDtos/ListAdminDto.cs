using Root.Domain.Enums;

namespace Root.Application.DTOs.AdminDtos;

public class ListAdminDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public AdministratorRole? Role { get; set; }
    public List<string> AcessLeves { get; set; } = [];
    public Guid UserId { get; set; }
    public string UserName { get; set; } 
}
