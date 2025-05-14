using Root.Domain.Entities.Packages;
using Root.Domain.Enums;

namespace Root.Domain.Entities;

public class Reserve : Entity
{
    public Client Client { get; set; }
    public Guid ClientId { get; set; }

    public Package Package { get; set; }
    public Guid PackageId { get; set; }
    public ReserveStatus Status { get; set; } = ReserveStatus.Pending;

    public int PeopleCount { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
}