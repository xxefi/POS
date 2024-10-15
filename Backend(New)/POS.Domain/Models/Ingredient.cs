namespace POS.Domain.Models;

public class Ingredient
{
    public const int MAX_NAME_LENGTH = 100;
        
    private Ingredient(Guid id, string name, decimal quantity, decimal unitPrice)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Quantity { get; }
    public decimal UnitPrice { get; }

    public static (Ingredient Ingredient, string Errors) Create(Guid id, string name, decimal quantity, decimal unitPrice)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(name) ? "Name cannot be empty" : null,
                name.Length > MAX_NAME_LENGTH ? $"Name cannot exceed {MAX_NAME_LENGTH} characters" : null,
                quantity < 0 ? "Quantity cannot be negative" : null,
                unitPrice < 0 ? "Unit price cannot be negative" : null
            }
            .Where(e => e != null)
            .ToList();

        var ingredient = new Ingredient(id, name, quantity, unitPrice);
        return (ingredient, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}