using Root.Domain.Enums;

namespace Root.Domain.Entities;

public class Administrator : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public AdministratorRole? Role { get; set; }
    public List<AdministratorAcess> AcessLeves { get; set; } = [];
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}