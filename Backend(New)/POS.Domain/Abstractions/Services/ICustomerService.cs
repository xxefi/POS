using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ICustomerService
{
    Task<ICollection<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(Guid customerId);
    Task<Customer> GetCustomerByEmailAsync(string email);
    Task AddCustomerAsync(CustomerEntity customer);
    Task UpdateCustomerAsync(Customer customer);
    Task RemoveCustomerAsync(Guid customerId);
}