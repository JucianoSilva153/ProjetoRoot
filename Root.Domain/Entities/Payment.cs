using Root.Domain.Enums;

namespace Root.Domain.Entities;

public class Payment : Entity
{
    public Reserve Reserve { get; set; }    
    public Guid ReserveId { get; set; }

    public PaymentMethod PaymentMethod { get; set; }
    public decimal PaymentValue { get; set; }
}