namespace POS.Domain.Models;

public class Category
{
    public const int MAX_NAME_LENGTH = 50;
    public const int MAX_DESCRIPTION_LENGTH = 200;

    private Category(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
        
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
        
    public static (Category Category, string Errors) Create(Guid id, string name, string description)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(name) ? "Name cannot be empty" : null,
                name.Length > MAX_NAME_LENGTH ? $"Name cannot exceed {MAX_NAME_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(description) ? "Description cannot be empty" : null,
                description.Length > MAX_DESCRIPTION_LENGTH ? $"Description cannot exceed {MAX_DESCRIPTION_LENGTH} characters" : null
            }
            .Where(e => e != null)
            .ToList();

        var category = new Category(id, name, description);
        return (category, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}