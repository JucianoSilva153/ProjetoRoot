using Root.Domain.Enums;

namespace Root.Application.DTOs.PaymentDtos;

public class ListPaymentDto
{
    public Guid Id { get; set; }
    public Guid ReserveId { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    public decimal PaymentValue { get; set; }
}
