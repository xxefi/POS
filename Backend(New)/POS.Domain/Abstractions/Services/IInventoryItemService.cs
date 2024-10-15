using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IInventoryItemService
{
    Task<ICollection<InventoryItem>> GetAllInventoryItemsAsync();
    Task<InventoryItem> GetInventoryItemByIdAsync(Guid inventoryItemId);
    Task AddInventoryItemAsync(InventoryItemEntity item);
    Task UpdateInventoryItemAsync(InventoryItem item);
    Task RemoveInventoryItemAsync(Guid inventoryItemId);
}