namespace POS.Domain.Entities;

public class TerminalEntity
{
    public Guid Id { get; set; }
    public string TerminalName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public ICollection<TerminalSettingsEntity>? Settings { get; set; } = [];
}
