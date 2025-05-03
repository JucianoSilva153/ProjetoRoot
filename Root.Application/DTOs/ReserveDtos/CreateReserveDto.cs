namespace Root.Application.DTOs.ReserveDtos;

public class CreateReserveDto
{
    public Guid ClientId { get; set; }
    public Guid PackageId { get; set; }
    public int PeopleCount { get; set; }
}
