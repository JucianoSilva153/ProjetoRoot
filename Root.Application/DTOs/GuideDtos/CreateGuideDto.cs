namespace Root.Application.DTOs.GuideDtos;

public class CreateGuideDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<string>? Idioms { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }

    public Guid UserId { get; set; }
}