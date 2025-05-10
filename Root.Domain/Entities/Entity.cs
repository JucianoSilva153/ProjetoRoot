namespace Root.Domain.Entities;

public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
    public Guid? ModifiedBy { get; set; } = null;
}