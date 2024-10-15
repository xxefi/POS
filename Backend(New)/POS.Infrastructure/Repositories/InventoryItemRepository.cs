
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;

namespace POS.Infrastructure.Repositories;

public class InventoryItemRepository : IInventoryItemRepository 
{
    private readonly POSContext _context;

    public InventoryItemRepository(POSContext context)
        => _context = context;

    private static InventoryItem CreateInventoryItemDB(InventoryItemEntity entity)
    {
        var result = InventoryItem.Create(entity.Id, entity.Name, entity.Quantity, entity.UnitPrice, entity.ExpiryDate);

        if (!string.IsNullOrEmpty(result.Errors)) throw new InvalidOperationException(result.Errors);
        return result.InventoryItem;
    }
    public async Task AddAsync(InventoryItemEntity model)
    {
        var (inventoryItem, error) = InventoryItem.Create(model.Id, model.Name, model.Quantity, model.UnitPrice, model.ExpiryDate);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new InventoryItemEntity
        {
            Name = inventoryItem.Name,
            Quantity = inventoryItem.Quantity,
            UnitPrice = inventoryItem.UnitPrice,
            ExpiryDate = inventoryItem.ExpiryDate,
        };

        await _context.InventoryItems.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<InventoryItem>> FindAsync(Expression<Func<InventoryItemEntity, bool>> predicate)
    {
        var entities = await _context.InventoryItems
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();

        return entities
            .Select(CreateInventoryItemDB)
            .ToList();
    }

    public async Task<ICollection<InventoryItem>> GetAllAsync()
    {
        var entities = await _context.InventoryItems
                .AsNoTracking()
                .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No inventory item found");

        return entities
            .Select(CreateInventoryItemDB)
            .ToList();
    }

    public async Task<InventoryItem> GetByIdAsync(Guid id)
    {
        var entity = await _context.InventoryItems
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Inventory item not found");

        return CreateInventoryItemDB(entity);
    }

    public async Task<InventoryItem?> GetItemByIdAsync(Guid itemId)
    {
        var entity = await _context.InventoryItems
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == itemId);

        return entity == null ? null : CreateInventoryItemDB(entity);
    }

    public async Task<ICollection<InventoryItem>> GetItemsByInventoryIdAsync(Guid inventoryId)
    {
        var entities = await _context.InventoryItems
                .Where(i => i.InventoryId == inventoryId)
                .ToListAsync();

        return entities
            .Select(CreateInventoryItemDB)
            .ToList();
    }

    public async Task Remove(InventoryItem model)
    {
        var entity = await _context.InventoryItems.FindAsync(model.Id)
               ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Inventory item not found");

        _context.InventoryItems.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(InventoryItem model)
    {
        var entity = await _context.InventoryItems.FindAsync(model.Id)
               ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Inventory item not found");

        entity.Name = model.Name;
        entity.Quantity = model.Quantity;
        entity.UnitPrice = model.UnitPrice;
        entity.ExpiryDate = model.ExpiryDate;

        await _context.SaveChangesAsync();
    }
}
