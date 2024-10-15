using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
        => _transactionRepository = transactionRepository;
    
    public async Task<ICollection<Transaction>> GetAllTransactionsAsync()
    {
        return await _transactionRepository.GetAllAsync();
    }

    public async Task<Transaction> GetTransactionByIdAsync(Guid transactionId)
    {
        return await _transactionRepository.GetByIdAsync(transactionId);
    }

    public async Task AddTransactionAsync(TransactionEntity transaction)
    {
        await _transactionRepository.AddAsync(transaction);
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        var existingTransaction = await _transactionRepository.GetByIdAsync(transaction.Id);
        await _transactionRepository.Update(existingTransaction);
    }

    public async Task RemoveTransactionAsync(Guid transactionId)
    {
        var existingTransaction = await _transactionRepository.GetByIdAsync(transactionId);
        await _transactionRepository.Remove(existingTransaction);
    }
}