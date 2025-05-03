namespace Root.Application.DTOs.PostDtos;

public class ListPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }

    public List<string> CategoryNames { get; set; } // ou List<Guid> CategoryIds, se preferir
}
