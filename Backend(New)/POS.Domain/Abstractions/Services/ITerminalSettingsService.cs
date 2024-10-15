using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ITerminalSettingsService
{
    Task<TerminalSettings?> GetSettingsByTerminalIdAsync(Guid terminalId);
    Task UpdateSettingsAsync(TerminalSettings settings);
}