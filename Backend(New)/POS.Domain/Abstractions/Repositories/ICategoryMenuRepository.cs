using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ICategoryMenuRepository : IGenericRepository<CategoryMenu, CategoryMenuEntity>
{
    Task<ICollection<CategoryMenu>> GetMenuByCategoryAsync(Guid categoryId);
    Task<CategoryMenu?> GetByMenuItemIdAsync(Guid menuItemId);
}