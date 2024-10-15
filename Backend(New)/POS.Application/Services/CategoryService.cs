using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;
    
    public async Task<ICollection<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
    {
        return await _categoryRepository.GetByIdAsync(categoryId);
    }

    public async Task AddCategoryAsync(CategoryEntity category)
    {
        await _categoryRepository.AddAsync(category);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(category.Id);
        await _categoryRepository.Update(existingCategory);
    }

    public async Task RemoveCategoryAsync(Guid categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        await _categoryRepository.Remove(category);
    }
}