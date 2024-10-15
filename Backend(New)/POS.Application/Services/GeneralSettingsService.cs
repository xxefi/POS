using POS.Domain.Abstractions.Services;
using POS.Domain.Models;

namespace POS.Application.Services;

public class GeneralSettingsService : IGeneralSettingsService
{
    private readonly IGeneralSettingsService _generalSettingsService;

    public GeneralSettingsService(IGeneralSettingsService generalSettingsService)
        => _generalSettingsService = generalSettingsService;
    
    public async Task<ICollection<GeneralSettings?>> GetSettingsAsync()
    {
        return await _generalSettingsService.GetSettingsAsync();
    }

    public async Task AddSettingsAsync(GeneralSettings generalSettingsEntity)
    {
        await _generalSettingsService.AddSettingsAsync(generalSettingsEntity);
    }
}