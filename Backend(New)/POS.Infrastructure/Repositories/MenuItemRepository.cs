
using Microsoft.EntityFrameworkCore;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;
using POS.Application.Exceptions;

namespace POS.Infrastructure.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly POSContext _context;

    public MenuItemRepository(POSContext context)
        => _context = context;

    private static MenuItem CreateMenuItemDB(MenuItemEntity entity)
    {
        var result = MenuItem.Create(entity.Id, entity.Name, entity.Description, entity.Price, entity.Quantity);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.MenuItem;
    }
    public async Task AddAsync(MenuItemEntity model)
    {
        var (menuItem, error) = MenuItem.Create(model.Id, model.Name, model.Description, model.Price, model.Quantity);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new MenuItemEntity
        {
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            Quantity = menuItem.Quantity,
        };

        await _context.MenuItems.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<MenuItem>> FindAsync(Expression<Func<MenuItemEntity, bool>> predicate)
    {
        var entities = await _context.MenuItems
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateMenuItemDB)
            .ToList();
    }

    public async Task<ICollection<MenuItem>> GetAllAsync()
    {
        var entities = await _context.MenuItems
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No menu items found");

        return entities
            .Select(CreateMenuItemDB)
            .ToList();
    }

    public async Task<ICollection<MenuItem>> GetByCategoryIdAsync(Guid categoryId)
    {
        var entities = await _context.MenuItems
            .AsNoTracking()
            .Where(m => m.CategoryId == categoryId)
            .ToListAsync();

        return entities
            .Select(CreateMenuItemDB)
            .ToList();
    }

    public async Task<MenuItem> GetByIdAsync(Guid id)
    {
        var entity = await _context.MenuItems
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound,"MenuItem not found");

        return CreateMenuItemDB(entity);
    }

    public async Task Remove(MenuItem model)
    {
        var entity = await _context.MenuItems.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound,"MenuItem not found");

        _context.MenuItems.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(MenuItem model)
    {
        var entity = await _context.MenuItems.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound,"MenuItem not found");

        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.Price = model.Price;
        entity.Quantity = model.Quantity;

        await _context.SaveChangesAsync();
    }
}
