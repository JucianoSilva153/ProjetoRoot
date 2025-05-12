namespace Root.Application.DTOs.UserDtos;

public class LoginListUserDto
{
    public Guid UserTypeId { get; set; }
    public ListUserDto User { get; set; }
    public string Token { get; set; }
}