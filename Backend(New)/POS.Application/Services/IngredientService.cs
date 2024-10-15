using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientService(IIngredientRepository ingredientRepository)
        => _ingredientRepository = ingredientRepository;
    
    public async Task<ICollection<Ingredient>> GetAllIngredientsAsync()
    {
        return await _ingredientRepository.GetAllAsync();
    }

    public async Task<Ingredient> GetIngredientByIdAsync(Guid ingredientId)
    {
        return await _ingredientRepository.GetByIdAsync(ingredientId);
    }

    public async Task AddIngredientAsync(IngredientEntity ingredient)
    {
        await _ingredientRepository.AddAsync(ingredient);
    }

    public async Task UpdateIngredientAsync(Ingredient ingredient)
    {
        var existingIngredient = await _ingredientRepository.GetByIdAsync(ingredient.Id);
        await _ingredientRepository.Update(existingIngredient);
    }

    public async Task RemoveIngredientAsync(Guid ingredientId)
    {
        var existingIngredient = await _ingredientRepository.GetByIdAsync(ingredientId);
        await _ingredientRepository.Remove(existingIngredient);
    }
}