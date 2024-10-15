using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly POSContext _context;

    public TransactionRepository(POSContext context)
        => _context = context;
    
    private static Transaction CreateTransactionDB(TransactionEntity entity)
    {
        var result = Transaction.Create(entity.Id, entity.CustomerId, entity.Amount, entity.TransactionDate,
            entity.TransactionType, entity.Description);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Transaction;
    }
    
    public async Task<Transaction> GetByIdAsync(Guid id)
    {
        var entity = await _context.Transactions
                         .AsNoTracking()
                         .FirstOrDefaultAsync(t => t.Id == id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Transaction not found");

        return CreateTransactionDB(entity);
    }

    public async Task<ICollection<Transaction>> GetAllAsync()
    {
        var entities = await _context.Transactions
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No transactions found");

        return entities
            .Select(CreateTransactionDB)
            .ToList();
    }

    public async Task AddAsync(TransactionEntity model)
    {
        var (transaction, error) = Transaction.Create(model.Id, model.CustomerId, model.Amount, model.TransactionDate, 
            model.TransactionType, model.Description);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new TransactionEntity
        {
            Amount = transaction.Amount,
            TransactionDate = transaction.TransactionDate,
            TransactionType = transaction.TransactionType,
            Description = transaction.Description
        };

        await _context.Transactions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Transaction model)
    {
        var entity = await _context.Transactions.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Transaction not found");

        _context.Transactions.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Transaction model)
    {
        var entity = await _context.Transactions.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Transaction not found");
        
        entity.Amount = model.Amount;   
        entity.TransactionType = model.TransactionType;
        entity.TransactionDate = model.TransactionDate;
        entity.Description = model.Description;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Transaction>> FindAsync(Expression<Func<TransactionEntity, bool>> predicate)
    {
        var entities = await _context.Transactions
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateTransactionDB)
            .ToList();
    }


    public async Task<ICollection<Transaction>> GetByCustomerIdAsync(Guid customerId)
    {
        var entities = await _context.Transactions
            .AsNoTracking()
            .Where(t => t.CustomerId == customerId)
            .ToListAsync();

        return entities
            .Select(CreateTransactionDB)
            .ToList();
    }

    public async Task<ICollection<Transaction>> GetTransactionsByDateAsync(DateTime date)
    {
        var entities = await _context.Transactions
            .AsNoTracking()
            .Where(t => t.TransactionDate.Date == date.Date)
            .ToListAsync();

        return entities
            .Select(CreateTransactionDB)
            .ToList();
    }
}