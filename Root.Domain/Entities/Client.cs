namespace Root.Domain.Entities;

public class Client : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Nationality { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}