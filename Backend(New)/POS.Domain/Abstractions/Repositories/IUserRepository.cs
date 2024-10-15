using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IUserRepository : IGenericRepository<User, UserEntity>
{
    Task<User> GetByEmailAsync(string email);
    Task<User?> GetByPhoneNumberAsync(string phone); 
}
