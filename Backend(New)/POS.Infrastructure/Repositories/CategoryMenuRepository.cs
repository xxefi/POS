using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class CategoryMenuRepository : ICategoryMenuRepository
{
    private readonly POSContext _context;

    public CategoryMenuRepository(POSContext context)
        => _context = context;

    private static CategoryMenu CreateCategoryMenuDB(CategoryMenuEntity categoryMenuEntity)
    {
        var result = CategoryMenu.Create(categoryMenuEntity.Id, categoryMenuEntity.Name, categoryMenuEntity.Description);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.CategoryMenu;
    }
    
    public async Task<CategoryMenu> GetByIdAsync(Guid id)
    {
        var categoryMenuEntity = await _context.CategoryMenus
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Category Menu Not Found");
        
        return CreateCategoryMenuDB(categoryMenuEntity);
    }

    public async Task<ICollection<CategoryMenu>> GetAllAsync()
    {
        var categoryMenus = await _context.CategoryMenus
            .AsNoTracking()
            .ToListAsync();
        
        if (!categoryMenus.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No Category Menu Found");

        return categoryMenus
            .Select(CreateCategoryMenuDB)
            .ToList();
    }

    public async Task AddAsync(CategoryMenuEntity model)
    {
        var (categoryMenus, error) = CategoryMenu.Create(
            model.Id, model.Name, model.Description);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var categoryMenuEntity = new CategoryMenuEntity
        {
            Name = categoryMenus.Name,
            Description = categoryMenus.Description
        };
        await _context.CategoryMenus.AddAsync(categoryMenuEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(CategoryMenu model)
    {
        var categoryMenus = await _context.CategoryMenus.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Category Menu Not Found");
        
        _context.CategoryMenus.Remove(categoryMenus);
    }

    public async Task Update(CategoryMenu model)
    {
        var categoryMenus = await _context.CategoryMenus.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Category Menu Not Found");
        
        categoryMenus.Description = model.Description;
        categoryMenus.Name = model.Name;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<CategoryMenu>> FindAsync(Expression<Func<CategoryMenuEntity, bool>> predicate)
    {
        var categoryMenuEntity = await _context.CategoryMenus
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return categoryMenuEntity
            .Select(CreateCategoryMenuDB)
            .ToList();
    }

    public async Task<ICollection<CategoryMenu>> GetMenuByCategoryAsync(Guid categoryId)
    {
        var categoryMenuEntity = await _context.CategoryMenus
            .AsNoTracking()
            .Where(c => c.Id == categoryId)
            .Include(m => m.MenuItems)
            .ToListAsync()
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Category Menu Not Found");

        return categoryMenuEntity
            .Select(CreateCategoryMenuDB)
            .ToList();

    }

    public async Task<CategoryMenu?> GetByMenuItemIdAsync(Guid menuItemId)
    {
        var menuItemEntity = await _context.MenuItems
            .AsNoTracking()
            .Include(mi => mi.CategoryMenu)
            .FirstOrDefaultAsync(mi => mi.Id == menuItemId)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Menu Item not found");

        var categoryMenuEntity = menuItemEntity.CategoryMenu.FirstOrDefault();

        return categoryMenuEntity == null
            ? null
            : CreateCategoryMenuDB(categoryMenuEntity);
    }
}