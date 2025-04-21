using Root.Domain.Entities.Packages;

namespace Root.Domain.Entities;

public class Reserve : Entity
{
    public Client Client { get; set; }
    public Guid ClientId { get; set; }

    public Package Package { get; set; }
    public Guid PackageId { get; set; }

    public int PeopleCount { get; set; }
    public decimal TotalPrice { get; set; }
}