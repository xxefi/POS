using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IReceiptService
{
    Task<ICollection<Receipt>> GetAllReceiptsAsync();
    Task<Receipt?> GetReceiptByIdAsync(Guid receiptId);
    Task AddReceiptAsync(ReceiptEntity receipt);
    Task UpdateReceiptAsync(Receipt receipt);
    Task RemoveReceiptAsync(Guid receiptId);
}