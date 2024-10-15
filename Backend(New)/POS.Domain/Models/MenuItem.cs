namespace POS.Domain.Models;

public class MenuItem
{
    public const int MAX_NAME_LENGTH = 100;
    public const int MAX_DESCRIPTION_LENGTH = 500;

    private MenuItem(Guid id, string name, string description, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        Description = description;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public static (MenuItem MenuItem, string Errors) Create(Guid id, string name, string description, decimal price, int quantity)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(name) ? "Name cannot be empty" : null,
                name.Length > MAX_NAME_LENGTH ? $"Name cannot exceed {MAX_NAME_LENGTH} characters" : null,
                description.Length > MAX_DESCRIPTION_LENGTH ? $"Description cannot exceed {MAX_DESCRIPTION_LENGTH} characters" : null,
                quantity <= 0 ? "Quantity must be greater than 0" : null,
                price <= 0 ? "Price must be greater than 0" : null
            }
            .Where(e => e != null)
            .ToList();

        var menuItem = new MenuItem(id, name, description, price, quantity);
        return (menuItem, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}