namespace POS.API.Contracts.TerminalSettings;

public record TerminalSettingsResponse(
    Guid Id,
    Guid TerminalId,
    string SettingKey,
    string SettingValue);