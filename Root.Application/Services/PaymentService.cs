using Root.Application.DTOs.PaymentDtos;
using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class PaymentService(IPaymentRepository paymentRepository)
{
    public async Task<bool> CreatePaymentAsync(CreatePaymentDto dto)
    {
        try
        {
            var payment = new Payment
            {
                ReserveId = dto.ReserveId,
                PaymentMethod = dto.PaymentMethod,
                PaymentValue = dto.PaymentValue
            };

            return await paymentRepository.CreateAsync(payment);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao criar pagamento: " + ex.Message);
        }

        return false;
    }

    public async Task<List<ListPaymentDto>> ListAllPaymentsAsync()
    {
        try
        {
            var payments = await paymentRepository.GetAllAsync();
            return payments.Select(p => new ListPaymentDto
            {
                Id = p.Id,
                ReserveId = p.ReserveId,
                PaymentMethod = p.PaymentMethod,
                PaymentValue = p.PaymentValue
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar pagamentos: " + ex.Message);
        }

        return [];
    }

    public async Task<ListPaymentDto?> GetPaymentByIdAsync(Guid id)
    {
        try
        {
            var payment = await paymentRepository.GetByIdAsync(id);
            if (payment is null)
                return null;

            return new ListPaymentDto
            {
                Id = payment.Id,
                ReserveId = payment.ReserveId,
                PaymentMethod = payment.PaymentMethod,
                PaymentValue = payment.PaymentValue
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar pagamento: " + ex.Message);
        }

        return null;
    }

    public async Task<bool> UpdatePaymentAsync(UpdatePaymentDto dto)
    {
        try
        {
            var payment = await paymentRepository.GetByIdAsync(dto.Id);
            if (payment is null)
                return false;

            payment.PaymentMethod = dto.PaymentMethod ?? payment.PaymentMethod;
            payment.PaymentValue = dto.PaymentValue ?? payment.PaymentValue;

            return await paymentRepository.UpdateAsync(payment);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao atualizar pagamento: " + ex.Message);
        }

        return false;
    }

    public async Task<bool> DeletePaymentAsync(Guid id)
    {
        try
        {
            return await paymentRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao deletar pagamento: " + ex.Message);
        }

        return false;
    }
}
