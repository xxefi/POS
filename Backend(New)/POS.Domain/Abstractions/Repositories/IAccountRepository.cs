
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IAccountRepository : IGenericRepository<Account, AccountEntity>
{
    Task<Account?> GetByEmailAsync(string email);
}