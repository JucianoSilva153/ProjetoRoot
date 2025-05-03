namespace Root.Application.DTOs.PostDtos;

public class UpdatePostDto
{
    public Guid Id { get; set; }
    
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Image { get; set; }

    public List<Guid>? CategoryIds { get; set; }
}
