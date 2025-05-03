using Root.Domain.Enums;

namespace Root.Application.DTOs.UserDtos;

public class ListUserDto
{
    public Guid Id { get; set; } 
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Contact { get; set; }
    public UserType Type { get; set; }
}
