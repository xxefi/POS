using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
        => _customerRepository = customerRepository;
    
    public async Task<ICollection<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
    {
        return await _customerRepository.GetByIdAsync(customerId);
    }

    public async Task<Customer> GetCustomerByEmailAsync(string email)
    {
        return await _customerRepository.GetByEmailAsync(email);
    }

    public async Task AddCustomerAsync(CustomerEntity customer)
    {
        await _customerRepository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(customer.Id);
        await _customerRepository.Update(existingCustomer);
    }

    public async Task RemoveCustomerAsync(Guid customerId)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(customerId);
        await _customerRepository.Update(existingCustomer);
    }
}