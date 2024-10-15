
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;
using static BCrypt.Net.BCrypt;

namespace POS.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly POSContext _context;

    public AccountRepository(POSContext context)
        => _context = context;
    private static Account CreateAccountDB(AccountEntity accountEntity)
    {
        var result = Account.Create(accountEntity.Id, accountEntity.Username, accountEntity.Email, accountEntity.Password);

        if (!string.IsNullOrEmpty(result.Error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Error);
        return result.Account;
    }
    public async Task AddAsync(AccountEntity model)
    {
        var (account, error) = Account.Create(
            model.Id,
            model.Username,
            model.Email,
            model.Password);

        if (!string.IsNullOrEmpty(error)) 
            throw new InvalidOperationException(error);
        
        var existingAccount = await _context.Accounts
            .AsNoTracking()
            .AnyAsync(a => a.Email == account.Email);
        
        if (existingAccount) throw new MyAuthException(AuthErrorTypes.EmailAlreadyExists, "Email already exists");

        var accountEntity = new AccountEntity
        {
            Email = account.Email,
            Password = HashPassword(account.Password),
            Username = account.Username,
        };
        await _context.Accounts.AddAsync(accountEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Account>> FindAsync(Expression<Func<AccountEntity, bool>> predicate)
    {
        var accounts = await _context.Accounts
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return accounts
            .Select(CreateAccountDB)
            .ToList();
    }

    public async Task<Account?> GetByEmailAsync(string email)
    {
        var accountEntity = await _context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Email == email)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Account not found");

        return accountEntity == null ? null : CreateAccountDB(accountEntity);
    }

    public async Task<ICollection<Account>> GetAllAsync()
    {
        var accounts = await _context.Accounts
            .AsNoTracking()
            .ToListAsync();
        
        if (!accounts.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No accounts found");

        return accounts
            .Select(CreateAccountDB)
            .ToList();
    }

    public async Task<Account> GetByIdAsync(Guid id)
    {
        var accountEntity = await _context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Account not found");

        return CreateAccountDB(accountEntity);
    }

    public async Task Remove(Account model)
    {
        var accountEntity = await _context.Accounts.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Account not found");
        _context.Accounts.Remove(accountEntity);

        await _context.SaveChangesAsync();
    }

    public async Task Update(Account model)
    {
        var accountEntity = await _context.Accounts.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Account not found");

        accountEntity.Username = model.Username;
        accountEntity.Email = model.Email;
        accountEntity.Password = HashPassword(model.Password);

        await _context.SaveChangesAsync();
    }

}
