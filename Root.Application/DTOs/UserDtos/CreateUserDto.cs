using Root.Domain.Enums;

namespace Root.Application.DTOs.UserDtos;

public class CreateUserDto
{
    public string UserName { get; set; }
    public string Password { get; set; } 
    public string Email { get; set; }
    public string Contact { get; set; }
    public UserType Type { get; set; }
}