namespace POS.Domain.Entities;

public class InventoryEntity
{
    public Guid Id { get; set; }
    public string IngredientName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public Guid InventoryItemId { get; set; }
    public ICollection<InventoryItemEntity> InventoryItems { get; set; }
}
