namespace POS.Domain.Models;

public class InventoryItem
{
    public const int MAX_NAME_LENGTH = 100;

    private InventoryItem(Guid id, string name, int quantity, decimal unitPrice, DateTime expiryDate)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
        ExpiryDate = expiryDate;
    }

    public Guid Id { get; }
    public string Name { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }
    public DateTime ExpiryDate { get; }

    public static (InventoryItem InventoryItem, string Errors) Create(Guid id, string name, int quantity, decimal unitPrice, DateTime expiryDate)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(name) ? "Name cannot be empty" : null,
                name.Length > MAX_NAME_LENGTH ? $"Name cannot exceed {MAX_NAME_LENGTH} characters" : null,
                quantity <= 0 ? "Quantity must be greater than 0" : null,
                unitPrice < 0 ? "Unit price cannot be negative" : null,
                expiryDate < DateTime.Now ? "Expiry date must be in the future" : null
            }
            .Where(e => e != null)
            .ToList();

        var inventoryItem = new InventoryItem(id, name, quantity, unitPrice, expiryDate);
        return (inventoryItem, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}