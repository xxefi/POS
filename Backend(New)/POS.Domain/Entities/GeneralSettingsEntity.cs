namespace POS.Domain.Entities;

public class GeneralSettingsEntity
{
    public Guid Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
