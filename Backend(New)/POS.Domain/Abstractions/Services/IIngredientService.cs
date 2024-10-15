using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IIngredientService
{
    Task<ICollection<Ingredient>> GetAllIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(Guid ingredientId);
    Task AddIngredientAsync(IngredientEntity ingredient);
    Task UpdateIngredientAsync(Ingredient ingredient);
    Task RemoveIngredientAsync(Guid ingredientId);
}