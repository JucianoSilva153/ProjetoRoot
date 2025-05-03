using Root.Domain.Enums;

namespace Root.Application.DTOs.PaymentDtos;

public class CreatePaymentDto
{
    public Guid ReserveId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal PaymentValue { get; set; }
}
