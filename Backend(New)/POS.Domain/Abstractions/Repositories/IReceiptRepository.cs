using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IReceiptRepository : IGenericRepository<Receipt, ReceiptEntity>
{
    
}