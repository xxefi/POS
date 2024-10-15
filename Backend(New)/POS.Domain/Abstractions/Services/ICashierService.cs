using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ICashierService
{
    Task<ICollection<Cashier>> GetAllCashiersAsync();
    Task<Cashier> GetCashierByIdAsync(Guid cashierId);
    Task AddCashierAsync(CashierEntity cashier);
    Task UpdateCashierAsync(Cashier cashier);
    Task RemoveCashierAsync(Guid cashierId);
    
    
}