using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IPaymentRepository : IGenericRepository<Payment, PaymentEntity>
{
    Task<Payment?> GetByOrderIdAsync(Guid orderId);
    Task<ICollection<Payment>> GetByCustomerIdAsync(Guid customerId);
}
