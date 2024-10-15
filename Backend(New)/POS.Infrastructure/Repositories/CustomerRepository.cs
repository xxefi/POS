
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;

namespace POS.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly POSContext _context;

    public CustomerRepository(POSContext context)
        => _context = context;

    private static Customer CreateCustomerDB(CustomerEntity customerEntity)
    {
        var result = Customer.Create(customerEntity.Id, customerEntity.Email,
            customerEntity.PhoneNumber, customerEntity.FullName);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Customer;
    }
    public async Task AddAsync(CustomerEntity model)
    {
        var (customer, error) = Customer.Create(model.Id, model.Email,
            model.PhoneNumber, model.FullName);
        
        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);
        
        var existingCustomer = await _context.Customers
            .AsNoTracking()
            .AnyAsync(c => c.Email == customer.Email || c.PhoneNumber == customer.PhoneNumber);
        
        if (existingCustomer) throw new MyAuthException(AuthErrorTypes.CredentialsAlreadyExists, "Email and phone already exists");

        var customerEntity = new CustomerEntity
        {
            FullName = customer.FullName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber
        };
        
        await _context.Customers.AddAsync(customerEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Customer>> FindAsync(Expression<Func<CustomerEntity, bool>> predicate)
    {
        var customerEntities = await _context.Customers
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return customerEntities
            .Select(CreateCustomerDB)
            .ToList();
    }

    public async Task<ICollection<Customer>> GetAllAsync()
    {
        var customerEntities = await _context.Customers
            .AsNoTracking()
            .ToListAsync();
        
        if (!customerEntities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No customers found");

        return customerEntities
            .Select(CreateCustomerDB)
            .ToList();
    }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        var customerEntity = await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email == email);

        return customerEntity == null ? null : CreateCustomerDB(customerEntity);
    }

    public async Task<Customer> GetByIdAsync(Guid id)
    {
        var customerEntity = await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Customer Not Found");

        return CreateCustomerDB(customerEntity);
    }

    public async Task<ICollection<Customer>> GetCustomersBySaleIdAsync(Guid saleId)
    {
        var customers = await _context.Sales
            .AsNoTracking()
            .Where(s => s.Id == saleId)
            .SelectMany(s => s.Customers)
            .ToListAsync();

        return customers
            .Select(CreateCustomerDB)
            .ToList();
    }

    public async Task Remove(Customer model)
    {
        var customerEntity = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Customer Not Found");

        _context.Customers.Remove(customerEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Customer model)
    {
        var customerEntity = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Customer Not Found");

        customerEntity.FullName = model.FullName;
        customerEntity.Email = model.Email;
        customerEntity.PhoneNumber = model.PhoneNumber;

        _context.Customers.Update(customerEntity);
        await _context.SaveChangesAsync();
    }
}
