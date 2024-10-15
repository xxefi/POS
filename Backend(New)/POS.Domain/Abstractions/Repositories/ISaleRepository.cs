using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ISaleRepository : IGenericRepository<Sale, SaleEntity>
{
    Task<ICollection<Sale>> GetSalesByDateAsync(DateTime date);
    Task<ICollection<Sale>> GetSalesByCustomerIdAsync(Guid customerId);
}