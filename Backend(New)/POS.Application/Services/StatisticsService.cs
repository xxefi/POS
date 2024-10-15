using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IStatisticsRepository _statisticsRepository;

    public StatisticsService(IStatisticsRepository statisticsRepository)
        => _statisticsRepository = statisticsRepository;
    
    public async Task<ICollection<Statistics>> GetAllStatisticsAsync()
    {
        return await _statisticsRepository.GetAllAsync();
    }

    public async Task<Statistics> GetStatisticsByIdAsync(Guid statisticsId)
    {
        return await _statisticsRepository.GetByIdAsync(statisticsId);
    }

    public async Task AddStatisticsAsync(StatisticsEntity statistics)
    {
        await _statisticsRepository.AddAsync(statistics);
    }

    public async Task UpdateStatisticsAsync(Statistics statistics)
    {
        var existingStatistics = await _statisticsRepository.GetByIdAsync(statistics.Id);
        await _statisticsRepository.Update(existingStatistics);
    }

    public async Task RemoveStatisticsAsync(Guid statisticsId)
    {
        var existingStatistics = await _statisticsRepository.GetByIdAsync(statisticsId);
        await _statisticsRepository.Remove(existingStatistics);
    }
}