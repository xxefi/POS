namespace POS.Domain.Models;

public class Product
{
    public const int MAX_NAME_LENGTH = 100;

    private Product(Guid id, string name, decimal unitPrice, int stock)
    {
        Id = id;
        Name = name;
        UnitPrice = unitPrice;
        Stock = stock;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal UnitPrice { get; }
    public int Stock { get; }

    public static (Product Product, string Error) Create(Guid id, string name, decimal unitPrice, int stock)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(name) || name.Length > MAX_NAME_LENGTH ? 
                    $"Product name must be between 1 and {MAX_NAME_LENGTH} characters" : null,
                unitPrice < 0 ? "Product unit price cannot be negative" : null,
                stock < 0 ? "Product stock cannot be negative" : null
            }
            .Where(e => e != null)
            .ToList();

        var product = new Product(id, name, unitPrice, stock);
        return (product, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
    
}