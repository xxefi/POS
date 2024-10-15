using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ITransactionService
{
    Task<ICollection<Transaction>> GetAllTransactionsAsync();
    Task<Transaction> GetTransactionByIdAsync(Guid transactionId);
    Task AddTransactionAsync(TransactionEntity transaction);
    Task UpdateTransactionAsync(Transaction transaction);
    Task RemoveTransactionAsync(Guid transactionId);
}