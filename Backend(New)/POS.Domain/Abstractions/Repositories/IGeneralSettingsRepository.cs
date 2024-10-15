using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IGeneralSettingsRepository : IGenericRepository<GeneralSettings, GeneralSettingsEntity>
{
    Task<ICollection<GeneralSettings>> GetSettingsAsync();
}