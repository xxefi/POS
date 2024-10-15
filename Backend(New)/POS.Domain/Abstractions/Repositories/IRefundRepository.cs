using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IRefundRepository : IGenericRepository<Refund, RefundEntity>
{
    
}