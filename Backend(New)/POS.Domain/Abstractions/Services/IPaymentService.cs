using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IPaymentService
{
    Task<ICollection<Payment>> GetAllPaymentsAsync();
    Task<Payment> GetPaymentByIdAsync(Guid paymentId);
    Task AddPaymentAsync(PaymentEntity payment);
    Task UpdatePaymentAsync(Payment payment);
    Task RemovePaymentAsync(Guid paymentId);
}