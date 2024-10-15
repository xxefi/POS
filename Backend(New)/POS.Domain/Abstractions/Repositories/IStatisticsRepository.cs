using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IStatisticsRepository : IGenericRepository<Statistics, StatisticsEntity>
{
    Task<Statistics?> GetSalesStatisticsByDateAsync(DateTime date);
    Task<Statistics?> GetInventoryStatisticsAsync(Guid statisticsId);
}