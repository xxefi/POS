using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryService(IInventoryRepository inventoryRepository)
        => _inventoryRepository = inventoryRepository;
    
    public async Task<ICollection<Inventory>> GetAllInventoriesAsync()
    {
        return await _inventoryRepository.GetAllAsync();
    }

    public async Task<Inventory> GetInventoryByIdAsync(Guid inventoryId)
    {
        return await _inventoryRepository.GetByIdAsync(inventoryId);
    }

    public async Task AddInventoryAsync(InventoryEntity inventory)
    {
        await _inventoryRepository.AddAsync(inventory);
    }

    public async Task UpdateInventoryAsync(Inventory inventory)
    {
        var existingInventory = await _inventoryRepository.GetByIdAsync(inventory.Id);
        await _inventoryRepository.Update(existingInventory);
    }

    public async Task RemoveInventoryAsync(Guid inventoryId)
    {
        var existingInventory = await _inventoryRepository.GetByIdAsync(inventoryId);
        await _inventoryRepository.Remove(existingInventory);
    }
}