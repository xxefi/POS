
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;

namespace POS.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly POSContext _context;

    public CategoryRepository(POSContext context)
        => _context = context;

    private static Category CreateCategoryDB(CategoryEntity categoryEntity)
    {
        var result = Category.Create(categoryEntity.Id, categoryEntity.Name, categoryEntity.Description);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Category;
    }
    public async Task AddAsync(CategoryEntity model)
    {
        var (category, error) = Category.Create(
            model.Id, model.Name, model.Description);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var categoryEntity = new CategoryEntity
        {
            Name = category.Name,
            Description = category.Description,
        };

        await _context.Categories.AddAsync(categoryEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Category>> FindAsync(Expression<Func<CategoryEntity, bool>> predicate)
    {
        var categoryEntity = await _context.Categories
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return categoryEntity
            .Select(CreateCategoryDB)
            .ToList();
    }

    public async Task<ICollection<Category>> GetAllAsync()
    {
        var categoryEntity = await _context.Categories
            .AsNoTracking()
            .ToListAsync();
        
        if (!categoryEntity.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No Category found");

        return categoryEntity
            .Select(CreateCategoryDB)
            .ToList();
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        var categoryEntity = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Category Not Found");

        return CreateCategoryDB(categoryEntity);
    }

    public async Task<ICollection<Category>> GetCategoriesWithItemsAsync()
    {
        var categoryEntities = await _context.Categories
            .AsNoTracking()
            .Include(c => c.MenuItems) 
            .ToListAsync();

        if (!categoryEntities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No categories data");

        return categoryEntities
            .Select(CreateCategoryDB)
            .ToList();
    }

    public async Task Remove(Category model)
    {
        var categoryEntity = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Category Not Found");

        _context.Categories.Remove(categoryEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Category model)
    {
        var categoryEntity = await _context.Categories
           .FirstOrDefaultAsync(c => c.Id == model.Id)
           ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Category Not Found");

        categoryEntity.Name = model.Name;
        categoryEntity.Description = model.Description;

        _context.Categories.Update(categoryEntity);
        await _context.SaveChangesAsync();
    }
}
