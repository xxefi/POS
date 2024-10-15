namespace POS.API.Contracts.CategoryMenu;

public record CategoryMenuRequest(
    string Name,
    string Description,
    Guid CategoryId,
    Guid MenuItemId);