using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IUserService
{
    Task<ICollection<User>> GetUsersAsync();
    Task<User> GetByIdAsync(Guid id);
    Task<User> CreateUserAsync(RegisterEntity user);
}
