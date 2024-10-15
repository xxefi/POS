using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ICustomerRepository : IGenericRepository<Customer, CustomerEntity>
{
    Task<Customer?> GetByEmailAsync(string email);
    Task<ICollection<Customer>> GetCustomersBySaleIdAsync(Guid saleId);
}