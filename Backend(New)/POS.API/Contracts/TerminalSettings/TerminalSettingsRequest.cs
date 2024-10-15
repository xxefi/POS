namespace POS.API.Contracts.TerminalSettings;

public record TerminalSettingsRequest(
    Guid TerminalId,
    string SettingKey,
    string SettingValue);