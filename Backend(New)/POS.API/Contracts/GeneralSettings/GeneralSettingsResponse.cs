namespace POS.API.Contracts.GeneralSettings;

public record GeneralSettingsResponse(
    Guid Id,
    string Key,
    string Value);