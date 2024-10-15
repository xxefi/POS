using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IAccountService
{
    Task<ICollection<Account>> GetAllAccountsAsync();
    Task<Account> GetAccountByIdAsync(Guid accountId);
    Task AddAccountAsync(AccountEntity account);
    Task UpdateAccountAsync(Account account);
    Task RemoveAccountAsync(Guid accountId);
}