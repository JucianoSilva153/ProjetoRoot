namespace Root.Application.DTOs.PostDtos;

public class CreatePostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }

    public List<Guid> CategoryIds { get; set; }
}
