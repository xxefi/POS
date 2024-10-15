using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class RefundService : IRefundService
{
    private readonly IRefundRepository _refundRepository;

    public RefundService(IRefundRepository refundRepository)
        => _refundRepository = refundRepository;
    
    public async Task<ICollection<Refund>> GetAllRefundsAsync()
    {
        return await _refundRepository.GetAllAsync();
    }

    public async Task<Refund?> GetRefundByIdAsync(Guid refundId)
    {
        return await _refundRepository.GetByIdAsync(refundId);
    }

    public async Task AddRefundAsync(RefundEntity refund)
    {
        await _refundRepository.AddAsync(refund);
    }

    public async Task UpdateRefundAsync(Refund refund)
    {
        var existingRefund = await _refundRepository.GetByIdAsync(refund.Id);
        await _refundRepository.Update(existingRefund);
    }

    public async Task RemoveRefundAsync(Guid refundId)
    {
        var existingRefund = await _refundRepository.GetByIdAsync(refundId);
        await _refundRepository.Remove(existingRefund);
    }
}