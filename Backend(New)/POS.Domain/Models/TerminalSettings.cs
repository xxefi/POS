namespace POS.Domain.Models;

public class TerminalSettings
{
    public const int MAX_KEY_LENGTH = 100;
    public const int MAX_VALUE_LENGTH = 500;

    private TerminalSettings(Guid id, string settingKey, string settingValue)
    {
        Id = id;
        SettingKey = settingKey;
        SettingValue = settingValue;
    }

    public Guid Id { get; }
    public string SettingKey { get; }
    public string SettingValue { get; }

    public static (TerminalSettings TerminalSettings, string Errors) Create(Guid id, string settingKey, string settingValue)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(settingKey) || settingKey.Length > MAX_KEY_LENGTH
                    ? $"Setting key must be between 1 and {MAX_KEY_LENGTH} characters"
                    : null,
                string.IsNullOrWhiteSpace(settingValue) || settingValue.Length > MAX_VALUE_LENGTH
                    ? $"Setting value must be between 1 and {MAX_VALUE_LENGTH} characters"
                    : null
            }
            .Where(e => e != null)
            .ToList();

        var terminalSettings = new TerminalSettings(id, settingKey, settingValue);
        return (terminalSettings, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}