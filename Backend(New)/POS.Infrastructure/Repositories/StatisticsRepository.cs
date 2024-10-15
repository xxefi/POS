using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly POSContext _context;

    public StatisticsRepository(POSContext context)
        => _context = context;
    
    public async Task<Statistics> GetByIdAsync(Guid id)
    {
            var entity = await _context.Statistics
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Statistics not found");

            return CreateStatisticsDB(entity);
    }
    
    private static Statistics CreateStatisticsDB(StatisticsEntity entity)
    {
        var result = Statistics.Create(entity.Id, entity.ReportDate, entity.TotalSales, entity.TotalExpenses);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Statistics;
    }

    public async Task<ICollection<Statistics>> GetAllAsync()
    {
        var entities = await _context.Statistics
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No statistics found");

        return entities
            .Select(CreateStatisticsDB)
            .ToList();
    }

    public async Task AddAsync(StatisticsEntity model)
    {
        var (statistics, error) = Statistics.Create(model.Id, model.ReportDate, model.TotalSales, model.TotalExpenses);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new StatisticsEntity
        {
            TotalSales = statistics.TotalSales,
            TotalExpenses = statistics.TotalExpenses,
            ReportDate = statistics.ReportDate,
        };

        await _context.Statistics.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Statistics model)
    {
        var entity = await _context.Statistics.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Statistics not found");

        _context.Statistics.Remove(entity);
        await _context.SaveChangesAsync();
    }
    public async Task Update(Statistics model)
    {
        var entity = await _context.Statistics.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Statistics not found");

        entity.TotalSales = model.TotalSales;
        entity.TotalExpenses = model.TotalExpenses;
        entity.ReportDate = model.ReportDate;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Statistics>> FindAsync(Expression<Func<StatisticsEntity, bool>> predicate)
    {
        var entities = await _context.Statistics
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateStatisticsDB)
            .ToList();
    }

    public async Task<Statistics?> GetSalesStatisticsByDateAsync(DateTime date)
    {
        var entity = await _context.Statistics
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.ReportDate.Date == date.Date);

        return entity != null ? CreateStatisticsDB(entity) : null;
    }

    public async Task<Statistics?> GetInventoryStatisticsAsync(Guid statisticsId)
    {
        var entity = await _context.Statistics
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == statisticsId);

        return entity != null ? CreateStatisticsDB(entity) : null;
    }
}