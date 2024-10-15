using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ICategoryService
{
    Task<ICollection<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(Guid categoryId);
    Task AddCategoryAsync(CategoryEntity category);
    Task UpdateCategoryAsync(Category category);
    Task RemoveCategoryAsync(Guid categoryId);
}