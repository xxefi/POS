using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class CategoryMenuService : ICategoryMenuService
{
    private readonly ICategoryMenuRepository _categoryMenuRepository;

    public CategoryMenuService(ICategoryMenuRepository categoryMenuRepository)
        => _categoryMenuRepository = categoryMenuRepository;
    
    public async Task<ICollection<CategoryMenu>> GetAllCategoriesAsync()
    {
        return await _categoryMenuRepository.GetAllAsync();
    }

    public async Task<CategoryMenu> GetCategoryByIdAsync(Guid categoryMenuId)
    {
        return await _categoryMenuRepository.GetByIdAsync(categoryMenuId);
    }

    public async Task AddCategoryAsync(CategoryMenuEntity categoryMenu)
        => await _categoryMenuRepository.AddAsync(categoryMenu);

    public async Task UpdateCategoryAsync(CategoryMenu categoryMenu)
    {
        var existingCategoryMenu = await _categoryMenuRepository.GetByIdAsync(categoryMenu.Id);
        await _categoryMenuRepository.Update(existingCategoryMenu);
    }

    public async Task RemoveCategoryAsync(Guid categoryMenuId)
    {
        var categoryMenu = await _categoryMenuRepository.GetByIdAsync(categoryMenuId);
        await _categoryMenuRepository.Remove(categoryMenu);
    }
}