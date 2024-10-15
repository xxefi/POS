using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IGeneralSettingsService
{
    Task<ICollection<GeneralSettings?>> GetSettingsAsync();
    Task AddSettingsAsync(GeneralSettings generalSettingsEntity);
}