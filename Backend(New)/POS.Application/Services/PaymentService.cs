using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
        => _paymentRepository = paymentRepository;
    
    public async Task<ICollection<Payment>> GetAllPaymentsAsync()
    {
        return await _paymentRepository.GetAllAsync();
    }

    public async Task<Payment> GetPaymentByIdAsync(Guid paymentId)
    {
        return await _paymentRepository.GetByIdAsync(paymentId);
    }

    public async Task AddPaymentAsync(PaymentEntity payment)
    {
        await _paymentRepository.AddAsync(payment);
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        var existingPayment = await _paymentRepository.GetByIdAsync(payment.Id);
        await _paymentRepository.Update(existingPayment);
    }

    public async Task RemovePaymentAsync(Guid paymentId)
    {
        var existingPayment = await _paymentRepository.GetByIdAsync(paymentId);
        await _paymentRepository.Remove(existingPayment);
    }
}