using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class RefundRepository : IRefundRepository

{
    private readonly POSContext _context;

    public RefundRepository(POSContext context)
        => _context = context;
    
    private static Refund CreateRefundDB(RefundEntity entity)
    {
        var result = Refund.Create(entity.Id, entity.RefundDate, entity.Amount);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Refund;
    }
    
    public async Task<Refund> GetByIdAsync(Guid id)
    {
            var entity = await _context.Refunds
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Refund not found");

            return CreateRefundDB(entity);
    }

    public async Task<ICollection<Refund>> GetAllAsync()
    {
        var entities = await _context.Refunds
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No refunds found");

        return entities
            .Select(CreateRefundDB)
            .ToList();
    }

    public async Task AddAsync(RefundEntity model)
    {
        var (refund, error) = Refund.Create(model.Id, model.RefundDate, model.Amount);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new RefundEntity
        {
            RefundDate = refund.RefundDate,
            Amount = refund.Amount
        };

        await _context.Refunds.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Refund model)
        {
            var entity = await _context.Refunds.FindAsync(model.Id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Refund not found");

            _context.Refunds.Remove(entity);
            await _context.SaveChangesAsync();
        }

    public async Task Update(Refund model)
    {
        var entity = await _context.Refunds.FindAsync(model.Id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Refund not found");
        
        entity.RefundDate = model.RefundDate;
        entity.Amount = model.Amount;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Refund>> FindAsync(Expression<Func<RefundEntity, bool>> predicate)
    {
        var entities = await _context.Refunds
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateRefundDB)
            .ToList();
    }
}