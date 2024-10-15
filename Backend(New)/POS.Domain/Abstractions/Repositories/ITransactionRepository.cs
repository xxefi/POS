using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ITransactionRepository : IGenericRepository<Transaction, TransactionEntity>
{
    Task<ICollection<Transaction>> GetByCustomerIdAsync(Guid customerId);
    Task<ICollection<Transaction>> GetTransactionsByDateAsync(DateTime date);
}
