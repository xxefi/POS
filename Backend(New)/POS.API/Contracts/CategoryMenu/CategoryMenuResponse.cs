using POS.API.Contracts.Category;
using POS.API.Contracts.MenuItem;

namespace POS.API.Contracts.CategoryMenu;

public record CategoryMenuResponse(
    Guid Id,
    string Name,
    string Description,
    Guid CategoryId,
    Guid MenuItemId,
    ICollection<CategoryResponse> Categories,
    ICollection<MenuItemResponse> MenuItems);