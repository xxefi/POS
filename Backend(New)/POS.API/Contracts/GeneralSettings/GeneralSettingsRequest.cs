namespace POS.API.Contracts.GeneralSettings;

public record GeneralSettingsRequest(
    string Key,
    string Value);