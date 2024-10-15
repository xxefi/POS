using POS.API.Contracts.MenuItem;

namespace POS.API.Contracts.Category;

public record CategoryResponse(
    Guid Id,
    string Name,
    string Description,
    ICollection<MenuItemResponse> MenuItems);