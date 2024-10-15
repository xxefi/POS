namespace POS.Domain.Models;

public class GeneralSettings
{
    public const int MAX_KEY_LENGTH = 50;
    public const int MAX_VALUE_LENGTH = 200;
        
    private GeneralSettings(Guid id, string key, string value)
    {
        Id = id;
        Key = key;
        Value = value;
    }

    public Guid Id { get; }
    public string Key { get; }
    public string Value { get; }
        
    public static (GeneralSettings GeneralSettings, string Errors) Create(Guid id, string key, string value)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(key) ? "Key cannot be empty" : null,
                key.Length > MAX_KEY_LENGTH ? $"Key cannot exceed {MAX_KEY_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(value) ? "Value cannot be empty" : null,
                value.Length > MAX_VALUE_LENGTH ? $"Value cannot exceed {MAX_VALUE_LENGTH} characters" : null
            }
            .Where(e => e != null)
            .ToList();
            
        var generalSettings = new GeneralSettings(id, key, value);
        return (generalSettings, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}