namespace POS.Domain.Models;

public class OrderItem
{
    public const int MAX_NAME_LENGTH = 100;

    private OrderItem(Guid id, string productName, int quantity, decimal price)
    {
        Id = id;
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }

    public Guid Id { get; }
    public string ProductName { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    public static (OrderItem OrderItem, string Errors) Create(Guid id, string productName, int quantity, decimal price)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(productName) ? "Product name cannot be empty" : null,
                productName.Length > MAX_NAME_LENGTH ? $"Product name cannot exceed {MAX_NAME_LENGTH} characters" : null,
                quantity <= 0 ? "Quantity must be greater than 0" : null,
                price <= 0 ? "Price must be greater than 0" : null
            }
            .Where(e => e != null)
            .ToList();

        var orderItem = new OrderItem(id, productName, quantity, price);
        return (orderItem, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}