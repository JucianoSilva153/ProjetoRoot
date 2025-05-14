namespace Root.Application.DTOs.ReserveDtos;

public class CreateReserveDto
{
    public Guid ClientId { get; set; }
    public Guid PackageId { get; set; }
    public int PeopleCount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime ReserveDate { get; set; } = DateTime.Now + TimeSpan.FromDays(7);
}
