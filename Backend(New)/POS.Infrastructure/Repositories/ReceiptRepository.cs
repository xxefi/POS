using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class ReceiptRepository : IReceiptRepository
{
    private readonly POSContext _context;

    public ReceiptRepository(POSContext context)
        => _context = context;
    
    private static Receipt CreateReceiptDB(ReceiptEntity entity)
    {
        var result = Receipt.Create(entity.Id, entity.DateIssued, entity.TotalAmount, entity.CreatedAt);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Receipt;
    }
    
    public async Task<Receipt> GetByIdAsync(Guid id)
        {
            var entity = await _context.Receipts
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Receipt not found");

            return CreateReceiptDB(entity);
        }

    public async Task<ICollection<Receipt>> GetAllAsync()
    {
        var entities = await _context.Receipts
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No Receipts found");

        return entities
            .Select(CreateReceiptDB)
            .ToList();
    }

    public async Task AddAsync(ReceiptEntity model)
    {
        var (receipt, error) = Receipt.Create(model.Id, model.DateIssued, model.TotalAmount, model.CreatedAt);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new ReceiptEntity
        {
            DateIssued = receipt.DateIssued,
            TotalAmount = receipt.TotalAmount,
            CreatedAt = receipt.CreatedAt,
        };

        await _context.Receipts.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Receipt model)
        {
            var entity = await _context.Receipts.FindAsync(model.Id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Receipt not found");

            _context.Receipts.Remove(entity);
            await _context.SaveChangesAsync();
        }

    public async Task Update(Receipt model)
    {
        var entity = await _context.Receipts.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Receipt not found");

        entity.DateIssued = model.DateIssued;
        entity.TotalAmount = model.TotalAmount;
        entity.CreatedAt = model.CreatedAt;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Receipt>> FindAsync(Expression<Func<ReceiptEntity, bool>> predicate)
    {
        var entities = await _context.Receipts
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateReceiptDB)
            .ToList();
    }
}