using Root.Domain.Enums;

namespace Root.Domain.Entities;

public class User : Entity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Contact { get; set; }
    public UserType Type { get; set; }
}