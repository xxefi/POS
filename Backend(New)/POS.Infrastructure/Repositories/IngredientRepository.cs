
using Microsoft.EntityFrameworkCore;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;
using POS.Application.Exceptions;

namespace POS.Infrastructure.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly POSContext _context;

    public IngredientRepository(POSContext context)
        => _context = context;

    private static Ingredient CreateIngredientDB(IngredientEntity ingredientEntity)
    {
        var result = Ingredient.Create(ingredientEntity.Id, ingredientEntity.Name, ingredientEntity.Quantity, ingredientEntity.UnitPrice);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Ingredient;
    }
    public async Task AddAsync(IngredientEntity model)
    {
        var (ingredient, error) = Ingredient.Create(model.Id, model.Name, model.Quantity, model.UnitPrice);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var ingredientEntity = new IngredientEntity
        {
            Name = ingredient.Name,
            Quantity = ingredient.Quantity,
            UnitPrice = ingredient.UnitPrice,
        };

        await _context.Ingredients.AddAsync(ingredientEntity);
        await _context.SaveChangesAsync(); 
    }

    public async Task<ICollection<Ingredient>> FindAsync(Expression<Func<IngredientEntity, bool>> predicate)
    {
        var ingredientEntities = await _context.Ingredients
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();

        return ingredientEntities
            .Select(CreateIngredientDB)
            .ToList();
    }

    public async Task<ICollection<Ingredient>> GetAllAsync()
    {
        var ingredientEntities = await _context.Ingredients
                .AsNoTracking()
                .ToListAsync();
        
        if (!ingredientEntities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No ingredients found");

        return ingredientEntities
            .Select(CreateIngredientDB)
            .ToList();
    }

    public async Task<Ingredient> GetByIdAsync(Guid id)
    {
        var ingredientEntity = await _context.Ingredients
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Ingredient not found");

        return CreateIngredientDB(ingredientEntity);
    }

    public async Task<ICollection<Ingredient>> GetByMenuItemIdAsync(Guid menuItemId)
    {
        var ingredients = await _context.MenuItems
                .Where(mi => mi.Id == menuItemId)
                .SelectMany(mi => mi.Ingredients)
                .ToListAsync();

        return ingredients
            .Select(CreateIngredientDB)
            .ToList();
    }

    public async Task<ICollection<Ingredient>> GetLowStockIngredientsAsync(int threshold)
    {
        var ingredients = await _context.Ingredients
                .Where(i => i.Quantity <= threshold)
                .ToListAsync();

        return ingredients
            .Select(CreateIngredientDB)
            .ToList();
    }

    public async Task Remove(Ingredient model)
    {
        var ingredientEntity = await _context.Ingredients.FindAsync(model.Id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Ingredient not found");

        _context.Ingredients.Remove(ingredientEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Ingredient model)
    {
        var ingredientEntity = await _context.Ingredients.FindAsync(model.Id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Ingredient not found");

        ingredientEntity.Name = model.Name;
        ingredientEntity.Quantity = model.Quantity;
        ingredientEntity.UnitPrice = model.UnitPrice;

        await _context.SaveChangesAsync();
    }
}
