using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class ReceiptService : IReceiptService
{
    private readonly IReceiptRepository _receiptRepository;

    public ReceiptService(IReceiptRepository receiptRepository)
        => _receiptRepository = receiptRepository;
    
    public async Task<ICollection<Receipt>> GetAllReceiptsAsync()
    {
        return await _receiptRepository.GetAllAsync();
    }

    public async Task<Receipt?> GetReceiptByIdAsync(Guid receiptId)
    {
        return await _receiptRepository.GetByIdAsync(receiptId);
    }

    public async Task AddReceiptAsync(ReceiptEntity receipt)
    {
        await _receiptRepository.AddAsync(receipt);
    }

    public async Task UpdateReceiptAsync(Receipt receipt)
    {
        var existingReceipt = await _receiptRepository.GetByIdAsync(receipt.Id);
        await _receiptRepository.Update(existingReceipt);
    }

    public async Task RemoveReceiptAsync(Guid receiptId)
    {   
        var existingReceipt = await _receiptRepository.GetByIdAsync(receiptId);
        await _receiptRepository.Remove(existingReceipt);
    }
}