using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly POSContext _context;

    public PaymentRepository(POSContext context)
        => _context = context;
    
    private static Payment CreatePaymentDB(PaymentEntity entity)
    {
        var result = Payment.Create(entity.Id, entity.OrderId, entity.CustomerId, entity.Amount, entity.PaymentMethod);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Payment;
    }

    public async Task<Payment> GetByIdAsync(Guid id)
    {
        var entity = await _context.Payments
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Payment not found");

            return CreatePaymentDB(entity);
    }

    public async Task<ICollection<Payment>> GetAllAsync()
    {
        var entities = await _context.Payments
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No payments found");

        return entities
            .Select(CreatePaymentDB)
            .ToList();
    }

    public async Task AddAsync(PaymentEntity model)
    {
        var (payment, error) = Payment.Create(model.Id, model.OrderId, model.CustomerId, model.Amount, model.PaymentMethod);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new PaymentEntity
        {
            OrderId = payment.OrderId,
            CustomerId = payment.CustomerId,
            Amount = payment.Amount,
            PaymentMethod = payment.PaymentMethod
        };

        await _context.Payments.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Payment model)
    {
        var entity = await _context.Payments.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Payment not found");

        _context.Payments.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Payment model)
    {
        var entity = await _context.Payments.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Payment not found");

        entity.OrderId = model.OrderId;
        entity.CustomerId = model.CustomerId;
        entity.Amount = model.Amount;
        entity.PaymentMethod = model.PaymentMethod;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Payment>> FindAsync(Expression<Func<PaymentEntity, bool>> predicate)
    {
        var entities = await _context.Payments
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreatePaymentDB)
            .ToList();
    }

    public async Task<Payment?> GetByOrderIdAsync(Guid orderId)
    {
        var entity = await _context.Payments
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.OrderId == orderId);

        return entity == null ? null : CreatePaymentDB(entity);
    }

    public async Task<ICollection<Payment>> GetByCustomerIdAsync(Guid customerId)
    {
        var entities = await _context.Payments
            .AsNoTracking()
            .Where(p => p.CustomerId == customerId)
            .ToListAsync();

        return entities
            .Select(CreatePaymentDB)
            .ToList();
    }
}