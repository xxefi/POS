using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class TableRepository : ITableRepository
{
    private readonly POSContext _context;

    public TableRepository(POSContext context)
        => _context = context;
    
    private static Table CreateTableDB(TableEntity entity)
    {
        var result = Table.Create(entity.Id, entity.Number, entity.IsBusy);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Table;
    }
    
    public async Task<Table> GetByIdAsync(Guid id)
        {
            var entity = await _context.Tables
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Table not found");

            return CreateTableDB(entity);
        }

    public async Task<ICollection<Table>> GetAllAsync()
    {
        var entities = await _context.Tables
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No tables found");

        return entities
            .Select(CreateTableDB)
            .ToList();
    }

    public async Task AddAsync(TableEntity model)
    {
        var (table, error) = Table.Create(model.Id, model.Number, model.IsBusy);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new TableEntity
        {
            Number = table.Number,
            IsBusy = table.IsBusy,
        };

        await _context.Tables.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Table model)
    {
        var entity = await _context.Tables.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Table not found");

        _context.Tables.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Table model)
    {
        var entity = await _context.Tables.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Table not found");
        
        entity.Number = model.Number;
        entity.IsBusy = model.IsBusy;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Table>> FindAsync(Expression<Func<TableEntity, bool>> predicate)
    {
        var entities = await _context.Tables
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateTableDB)
            .ToList();
    }

    public async Task<ICollection<Table>> GetAvailableTablesAsync()
    {
        var entities = await _context.Tables
            .AsNoTracking()
            .Where(t => t.IsBusy)
            .ToListAsync();

        return entities
            .Select(CreateTableDB)
            .ToList();
    }

    public async Task<Table?> GetTableByOrderIdAsync(Guid orderId)
    {
        var orderEntity = await _context.Orders
                              .AsNoTracking()
                              .FirstOrDefaultAsync(o => o.Id == orderId)
                          ?? throw new MyAuthException(AuthErrorTypes.NullCredentials, "Order is null");

        var tableEntity = await _context.Tables
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == orderEntity.TableId);

        return tableEntity != null ? CreateTableDB(tableEntity) : null;
    }
}