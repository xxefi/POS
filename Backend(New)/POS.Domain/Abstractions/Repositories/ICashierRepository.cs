using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ICashierRepository : IGenericRepository<Cashier, CashierEntity>
{
    Task<Cashier?> GetByEmailAsync(string email);
    Task<Cashier?> GetByPhoneNumberAsync(string phoneNumber);
}
