namespace Root.Domain.Entities;

public class Guide : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<string> Idioms { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}