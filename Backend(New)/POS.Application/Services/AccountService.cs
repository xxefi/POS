using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
        => _accountRepository = accountRepository;
    
    public async Task<ICollection<Account>> GetAllAccountsAsync()
    {
        return await _accountRepository.GetAllAsync();
    }

    public async Task<Account> GetAccountByIdAsync(Guid accountId)
    {
        return await _accountRepository.GetByIdAsync(accountId);
    }

    public async Task AddAccountAsync(AccountEntity account)
    {
        await _accountRepository.AddAsync(account);
    }

    public async Task UpdateAccountAsync(Account account)
    {
        var account1 = await _accountRepository.GetByIdAsync(account.Id);
        await _accountRepository.Update(account1);
    }

    public async Task RemoveAccountAsync(Guid accountId)
    {
        var account = await _accountRepository.GetByIdAsync(accountId);
        await _accountRepository.Remove(account);
    }
}