using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IMenuItemService
{
    Task<ICollection<MenuItem>> GetAllMenuItemsAsync();
    Task<MenuItem> GetMenuItemByIdAsync(Guid menuItemId);
    Task AddMenuItemAsync(MenuItemEntity menuItem);
    Task UpdateMenuItemAsync(MenuItem menuItem);
    Task RemoveMenuItemAsync(Guid menuItemId);
}