
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ICategoryRepository : IGenericRepository<Category, CategoryEntity>
{
   Task<ICollection<Category>> GetCategoriesWithItemsAsync();
}
