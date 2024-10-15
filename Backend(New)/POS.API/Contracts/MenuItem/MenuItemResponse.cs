namespace POS.API.Contracts.MenuItem;

public record MenuItemResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    string CategoryName,
    ICollection<string> Ingredients);