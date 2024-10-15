using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IStatisticsService
{
    Task<ICollection<Statistics>> GetAllStatisticsAsync();
    Task<Statistics> GetStatisticsByIdAsync(Guid statisticsId);
    Task AddStatisticsAsync(StatisticsEntity statistics);
    Task UpdateStatisticsAsync(Statistics statistics);
    Task RemoveStatisticsAsync(Guid statisticsId);
}