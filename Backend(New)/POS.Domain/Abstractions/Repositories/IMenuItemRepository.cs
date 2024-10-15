using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IMenuItemRepository : IGenericRepository<MenuItem, MenuItemEntity>
{
    Task<ICollection<MenuItem>> GetByCategoryIdAsync(Guid categoryId);
}
