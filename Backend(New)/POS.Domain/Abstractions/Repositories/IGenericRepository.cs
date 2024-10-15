
using System.Linq.Expressions;

namespace POS.Domain.Abstractions.Repositories;

public interface IGenericRepository<T, TEntity> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<ICollection<T>> GetAllAsync();
    Task AddAsync(TEntity model);
    Task Remove(T model);
    Task Update(T model);
    Task<ICollection<T>> FindAsync(Expression<Func<TEntity, bool>> predicate);
}
