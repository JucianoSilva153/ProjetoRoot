namespace Root.Application.DTOs.ClientDtos;

public class UpdateClientDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Nationality { get; set; }
}