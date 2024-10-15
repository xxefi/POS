using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IInventoryService
{
    Task<ICollection<Inventory>> GetAllInventoriesAsync();
    Task<Inventory> GetInventoryByIdAsync(Guid inventoryId);
    Task AddInventoryAsync(InventoryEntity inventory);
    Task UpdateInventoryAsync(Inventory inventory);
    Task RemoveInventoryAsync(Guid inventoryId);
}