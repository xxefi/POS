using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IInventoryRepository : IGenericRepository<Inventory, InventoryEntity>
{
    Task<ICollection<Inventory>> GetInventoriesWithLowStockAsync(int threshold);
}
