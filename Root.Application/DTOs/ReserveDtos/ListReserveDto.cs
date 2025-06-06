using Root.Domain.Enums;

namespace Root.Application.DTOs.ReserveDtos;

public class ListReserveDto
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }
    public Guid GuideId { get; set; }
    public string ClientName { get; set; } // ou um subobjeto ClientDto resumido
    public string GuideName { get; set; } // ou um subobjeto ClientDto resumido

    public Guid PackageId { get; set; }
    public string PackageName { get; set; } // ou subobjeto PackageDto

    public int PeopleCount { get; set; }
    public decimal TotalPrice { get; set; }
    public ReserveStatus ReserveStatus { get; set; }
    public DateTime ReserveDate { get; set; }
}
