using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Models;

namespace POS.Application.Services;

public class TerminalSettingsService : ITerminalSettingsService
{
    private readonly ITerminalSettingsRepository _terminalSettingsRepository;

    public TerminalSettingsService(ITerminalSettingsRepository terminalSettingsRepository)
        => _terminalSettingsRepository = terminalSettingsRepository;
    
    public async Task<TerminalSettings?> GetSettingsByTerminalIdAsync(Guid terminalId)
    {
        return await _terminalSettingsRepository.GetSettingsByTerminalIdAsync(terminalId);
    }

    public async Task UpdateSettingsAsync(TerminalSettings settings)
    {
        var existingTerminalSettings = await _terminalSettingsRepository.GetSettingsByTerminalIdAsync(settings.Id);
        await _terminalSettingsRepository.Update(existingTerminalSettings);
    }
}