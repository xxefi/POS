
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;

namespace POS.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly POSContext _context;

    public InventoryRepository(POSContext context)
        => _context = context;

    private static Inventory CreateInventoryDB(InventoryEntity entity)
    {
        var result = Inventory.Create(entity.Id, entity.IngredientName, entity.Quantity);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Inventory;
    }
    public async Task AddAsync(InventoryEntity model)
    {
        var (inventory, error) = Inventory.Create(model.Id, model.IngredientName, model.Quantity);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new InventoryEntity
        {
            IngredientName = inventory.IngredientName,
            Quantity = inventory.Quantity,
        };

        await _context.Inventories.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Inventory>> FindAsync(Expression<Func<InventoryEntity, bool>> predicate)
    {
        var entities = await _context.Inventories
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateInventoryDB)
            .ToList();
    }

    public async Task<ICollection<Inventory>> GetAllAsync()
    {
        var entities = await _context.Inventories
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No inventories found");

        return entities
            .Select(CreateInventoryDB)
            .ToList();
    }

    public async Task<Inventory> GetByIdAsync(Guid id)
    {
        var entity = await _context.Inventories
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Inventory not found");

        return CreateInventoryDB(entity);
    }

    public async Task<ICollection<Inventory>> GetInventoriesWithLowStockAsync(int threshold)
    {
        var inventories = await _context.Inventories
            .Include(i => i.InventoryItems)
            .Where(i => i.InventoryItems.Any(item => item.Quantity < threshold))
            .ToListAsync();

        return inventories
            .Select(CreateInventoryDB)
            .ToList();
    }

    public async Task Remove(Inventory model)
    {
        var entity = await _context.Inventories.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Inventory not found");

        _context.Inventories.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Inventory model)
    {
        var entity = await _context.Inventories.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Inventory not found");

        entity.IngredientName = model.IngredientName;
        entity.Quantity = model.Quantity;

        await _context.SaveChangesAsync();
    }
}
