namespace POS.Domain.Entities;

public class CategoryMenuEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public Guid MenuItemId { get; set; }
    public ICollection<CategoryEntity> Categories { get; set; } = [];
    public ICollection<MenuItemEntity> MenuItems { get; set; } = [];
}
