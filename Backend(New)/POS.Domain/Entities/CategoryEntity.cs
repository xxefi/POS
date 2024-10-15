namespace POS.Domain.Entities;

public class CategoryEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<MenuItemEntity> MenuItems { get; set; } = [];
}
