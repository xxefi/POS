
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;

namespace POS.Infrastructure.Repositories;

public class GeneralSettingsRepository : IGeneralSettingsRepository
{
    private readonly POSContext _context;

    public GeneralSettingsRepository(POSContext context)
        => _context = context;

    private static GeneralSettings CreateGeneralSettingsDB(GeneralSettingsEntity generalSettingsEntity)
    {
        var result = GeneralSettings.Create(generalSettingsEntity.Id, generalSettingsEntity.Key, generalSettingsEntity.Value);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.GeneralSettings;
    }
    public async Task AddAsync(GeneralSettingsEntity model)
    {
        var (generalSettings, error) = GeneralSettings.Create(model.Id, model.Key, model.Value);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var generalSettingsEntity = new GeneralSettingsEntity
        {
            Key = generalSettings.Key,
            Value = generalSettings.Value,
        };

        await _context.GeneralSettings.AddAsync(generalSettingsEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<GeneralSettings>> FindAsync(Expression<Func<GeneralSettingsEntity, bool>> predicate)
    {
        var settingsEntities = await _context.GeneralSettings
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return settingsEntities
            .Select(CreateGeneralSettingsDB)
            .ToList();
    }

    public async Task<ICollection<GeneralSettings>> GetAllAsync()
    {
        var settingsEntities = await _context.GeneralSettings
            .AsNoTracking()
            .ToListAsync();
        
        if (!settingsEntities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No settings found");

        return settingsEntities
            .Select(CreateGeneralSettingsDB)
            .ToList();
    }

    public async Task<GeneralSettings> GetByIdAsync(Guid id)
    {
        var settingsEntity = await _context.GeneralSettings
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "General setting not found");

        return CreateGeneralSettingsDB(settingsEntity);
    }

    public async Task<ICollection<GeneralSettings>> GetSettingsAsync()
    {
        var settingsEntities = await _context.GeneralSettings
            .AsNoTracking()
            .ToListAsync();

        return settingsEntities
            .Select(CreateGeneralSettingsDB)
            .ToList();
    }

    public async Task Remove(GeneralSettings model)
    {
        var settingsEntity = await _context.GeneralSettings.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "General setting not found");

        _context.GeneralSettings.Remove(settingsEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(GeneralSettings model)
    {
        var settingsEntity = await _context.GeneralSettings.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "General setting not found");

        settingsEntity.Key = model.Key;
        settingsEntity.Value = model.Value;

        await _context.SaveChangesAsync();
    }
}
