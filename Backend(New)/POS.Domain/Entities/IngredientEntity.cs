namespace POS.Domain.Entities;

public class IngredientEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public ICollection<MenuItemEntity> MenuItems { get; set; } = [];
}
