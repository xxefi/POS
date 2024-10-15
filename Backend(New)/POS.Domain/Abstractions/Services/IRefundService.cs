using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IRefundService
{
    Task<ICollection<Refund>> GetAllRefundsAsync();
    Task<Refund?> GetRefundByIdAsync(Guid refundId);
    Task AddRefundAsync(RefundEntity refund);
    Task UpdateRefundAsync(Refund refund);
    Task RemoveRefundAsync(Guid refundId);
}