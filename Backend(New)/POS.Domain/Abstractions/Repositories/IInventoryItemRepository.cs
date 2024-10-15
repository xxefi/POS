
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IInventoryItemRepository : IGenericRepository<InventoryItem, InventoryItemEntity>
{
    Task<ICollection<InventoryItem>> GetItemsByInventoryIdAsync(Guid inventoryId);
    Task<InventoryItem?> GetItemByIdAsync(Guid itemId);
}
