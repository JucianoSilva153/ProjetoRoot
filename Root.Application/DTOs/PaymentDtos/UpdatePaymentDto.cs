using Root.Domain.Enums;

namespace Root.Application.DTOs.PaymentDtos;

public class UpdatePaymentDto
{
    public Guid Id { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public decimal? PaymentValue { get; set; }
}
