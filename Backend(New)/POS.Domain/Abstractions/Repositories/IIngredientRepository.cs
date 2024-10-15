using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IIngredientRepository : IGenericRepository<Ingredient, IngredientEntity>
{
    Task<ICollection<Ingredient>> GetByMenuItemIdAsync(Guid menuItemId);
    Task<ICollection<Ingredient>> GetLowStockIngredientsAsync(int threshold);
}