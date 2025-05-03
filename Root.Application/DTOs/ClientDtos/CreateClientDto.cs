namespace Root.Application.DTOs.ClientDtos;

public class CreateClientDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Nationality { get; set; }

    public Guid UserId { get; set; }
}