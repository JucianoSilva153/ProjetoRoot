using Root.Domain.Enums;

namespace Root.Application.DTOs.UserDtos;

public class UpdateUserDto
{
    public Guid Id { get; set; } // Para identificar o usuário a ser atualizado
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Contact { get; set; }
    public UserType? Type { get; set; }
}