namespace Root.Domain.Entities.Blog;

public class Post : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }

    public string Image { get; set; }

    public ICollection<Category> Categories { get; set; }
}