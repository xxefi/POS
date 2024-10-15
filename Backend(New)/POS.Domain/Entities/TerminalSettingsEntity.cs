namespace POS.Domain.Entities;

public class TerminalSettingsEntity
{
    public Guid Id { get; set; }
    public Guid TerminalId { get; set; }
    public TerminalEntity? Terminal { get; set; }
    public string SettingKey { get; set; } = string.Empty;
    public string SettingValue { get; set; } = string.Empty;
}
