using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemService(IMenuItemRepository menuItemRepository)
        => _menuItemRepository = menuItemRepository;
    
    public async Task<ICollection<MenuItem>> GetAllMenuItemsAsync()
    {
        return await _menuItemRepository.GetAllAsync();
    }

    public async Task<MenuItem> GetMenuItemByIdAsync(Guid menuItemId)
    {
        return await _menuItemRepository.GetByIdAsync(menuItemId);
    }

    public async Task AddMenuItemAsync(MenuItemEntity menuItem)
    {
        await _menuItemRepository.AddAsync(menuItem);
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        var existingMenuItem = await _menuItemRepository.GetByIdAsync(menuItem.Id);
        await _menuItemRepository.Update(existingMenuItem);
    }

    public async Task RemoveMenuItemAsync(Guid menuItemId)
    {
        var existingMenuItem = await _menuItemRepository.GetByIdAsync(menuItemId);
        await _menuItemRepository.Remove(existingMenuItem);
    }
}