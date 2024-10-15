using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ITableRepository : IGenericRepository<Table, TableEntity>
{
    Task<ICollection<Table>> GetAvailableTablesAsync();
    Task<Table?> GetTableByOrderIdAsync(Guid orderId);
}
