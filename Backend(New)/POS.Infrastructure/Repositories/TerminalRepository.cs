using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class TerminalRepository : ITerminalRepository
{
    private readonly POSContext _context;

    public TerminalRepository(POSContext context)
        => _context = context;
    
    private static Terminal CreateTerminalDB(TerminalEntity entity)
    {
        var result = Terminal.Create(entity.Id, entity.TerminalName, entity.Location);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Terminal;
    }
    
    public async Task<Terminal> GetByIdAsync(Guid id)
    {
        var entity = await _context.Terminals
                         .AsNoTracking()
                         .FirstOrDefaultAsync(t => t.Id == id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Terminal not found");

        return CreateTerminalDB(entity);
    }


    public async Task<ICollection<Terminal>> GetAllAsync()
    {
        var entities = await _context.Terminals
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No terminals found");

        return entities
            .Select(CreateTerminalDB)
            .ToList();
    }

    public async Task AddAsync(TerminalEntity model)
    {
        var (terminal, error) = Terminal.Create(model.Id, model.Location, model.TerminalName);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new TerminalEntity
        {
            Location = terminal.Location,
            TerminalName = terminal.TerminalName
        };

        await _context.Terminals.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Terminal model)
    {
        var entity = await _context.Terminals.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Terminal not found");

        _context.Terminals.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Terminal model)
    {
        var entity = await _context.Terminals.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Terminal not found");

        entity.Location = model.Location;
        entity.TerminalName = model.TerminalName;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Terminal>> FindAsync(Expression<Func<TerminalEntity, bool>> predicate)
    {
        var entities = await _context.Terminals
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateTerminalDB)
            .ToList();
    }

    public async Task<ICollection<Terminal>> GetByLocationAsync(string location)
    {
        var entities = await _context.Terminals
            .AsNoTracking()
            .Where(t => t.Location == location)
            .ToListAsync();

        return entities
            .Select(CreateTerminalDB)
            .ToList();
    }

    public async Task<Terminal?> GetByTerminalIdAsync(Guid terminalId)
    {
        var entity = await _context.Terminals
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == terminalId);

        return entity != null ? CreateTerminalDB(entity) : null;
    } 
}