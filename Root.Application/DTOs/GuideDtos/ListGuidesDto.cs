namespace Root.Application.DTOs.GuideDtos;

public class ListGuidesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<string>? Idioms { get; set; } = [];
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string? Image { get; set; }

    public Guid UserId { get; set; }
    public string UserName { get; set; } // Ou um objeto UserInfoDto, se quiser
}
