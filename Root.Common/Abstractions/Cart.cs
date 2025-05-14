namespace Root.Common.Abstractions;

public class Cart
{
    public Guid OwnerId { get; set; }
    public List<Guid> Items { get; set; }
}