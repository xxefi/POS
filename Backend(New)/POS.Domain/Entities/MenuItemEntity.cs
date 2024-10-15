namespace POS.Domain.Entities;

public class MenuItemEntity
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public ICollection<CategoryMenuEntity> CategoryMenu  { get; set; } = [];
    public ICollection<IngredientEntity> Ingredients { get; set; } = [];
}
