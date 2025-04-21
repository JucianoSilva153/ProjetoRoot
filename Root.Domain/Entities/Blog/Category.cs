namespace Root.Domain.Entities.Blog;

public class Category : Entity
{
    public string Title { get; set; }

    public ICollection<Post> Posts { get; set; }
}