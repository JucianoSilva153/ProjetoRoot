using Root.Domain.Enums;

namespace Root.Application.DTOs.ReserveDtos;

public class UpdateReserveDto
{
    public Guid Id { get; set; }
    public Guid? GuideId { get; set; }
    public int? PeopleCount { get; set; }
    public DateTime? ReserveDate { get; set; }
    public ReserveStatus? ReserveStatus { get; set; }
}