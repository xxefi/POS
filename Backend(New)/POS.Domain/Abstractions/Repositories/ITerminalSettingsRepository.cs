using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ITerminalSettingsRepository : IGenericRepository<TerminalSettings, TerminalSettingsEntity>
{
    Task<TerminalSettings?> GetSettingsByTerminalIdAsync(Guid terminalId);
}