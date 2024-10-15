namespace POS.Domain.Models;

public class Inventory
{
    public const int MAX_INGREDIENT_NAME_LENGTH = 50;

    private Inventory(Guid id, string ingredientName, int quantity)
    {
        Id = id;
        IngredientName = ingredientName;
        Quantity = quantity;
    }

    public Guid Id { get; }
    public string IngredientName { get; }
    public int Quantity { get; }

    public static (Inventory Inventory, string Errors) Create(Guid id, string ingredientName, int quantity)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(ingredientName) ? "Ingredient name cannot be empty" : null,
                ingredientName.Length > MAX_INGREDIENT_NAME_LENGTH ? $"Ingredient name cannot exceed {MAX_INGREDIENT_NAME_LENGTH} characters" : null,
                quantity < 0 ? "Quantity cannot be negative" : null
            }
            .Where(e => e != null)
            .ToList();

        var inventory = new Inventory(id, ingredientName, quantity);
        return (inventory, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
    
}