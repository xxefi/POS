using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class TerminalSettingsRepository : ITerminalSettingsRepository
{
    private readonly POSContext _context;

    public TerminalSettingsRepository(POSContext context)
    {
        _context = context;
    }

    private static TerminalSettings CreateTerminalSettingsDB(TerminalSettingsEntity entity)
    {
        var result = TerminalSettings.Create(entity.Id, entity.SettingKey, entity.SettingValue);
        
        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.TerminalSettings;
    }

    public async Task<TerminalSettings> GetByIdAsync(Guid id)
    {
        var entity = await _context.TerminalSettings
            .AsNoTracking()
            .FirstOrDefaultAsync(ts => ts.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Terminal Settings not found");

        return CreateTerminalSettingsDB(entity);
    }

    public async Task<ICollection<TerminalSettings>> GetAllAsync()
    {
        var entities = await _context.TerminalSettings
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No Terminal Settings found");

        return entities.Select(CreateTerminalSettingsDB).ToList();
    }

    public async Task AddAsync(TerminalSettingsEntity model)
    {
        var entity = new TerminalSettingsEntity
        {
            SettingKey = model.SettingKey,
            SettingValue = model.SettingValue
        };

        await _context.TerminalSettings.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(TerminalSettings model)
    {
        var entity = await _context.TerminalSettings.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Terminal Settings not found");

        _context.TerminalSettings.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TerminalSettings model)
    {
        var entity = await _context.TerminalSettings.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Terminal Settings not found");

        
        entity.SettingKey = model.SettingKey;
        entity.SettingValue = model.SettingValue;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<TerminalSettings>> FindAsync(Expression<Func<TerminalSettingsEntity, bool>> predicate)
    {
        var entities = await _context.TerminalSettings
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities.Select(CreateTerminalSettingsDB).ToList();
    }

    public async Task<TerminalSettings?> GetSettingsByTerminalIdAsync(Guid terminalId)
    {
        var entity = await _context.TerminalSettings
            .AsNoTracking()
            .FirstOrDefaultAsync(ts => ts.TerminalId == terminalId);

        return entity != null ? CreateTerminalSettingsDB(entity) : null;
    }
}
 