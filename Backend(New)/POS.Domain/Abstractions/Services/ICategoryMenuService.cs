using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ICategoryMenuService
{
    Task<ICollection<CategoryMenu>> GetAllCategoriesAsync();
    Task<CategoryMenu> GetCategoryByIdAsync(Guid categoryMenuId);
    Task AddCategoryAsync(CategoryMenuEntity categoryMenu);
    Task UpdateCategoryAsync(CategoryMenu categoryMenu);
    Task RemoveCategoryAsync(Guid categoryMenuId);
}