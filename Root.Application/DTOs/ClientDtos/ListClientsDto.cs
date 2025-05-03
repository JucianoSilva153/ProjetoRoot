namespace Root.Application.DTOs.ClientDtos;

public class ListClientsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Nationality { get; set; }

    public Guid UserId { get; set; }
    public string UserName { get; set; } // ou outro campo relevante do User
}
