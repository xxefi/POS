using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using static BCrypt.Net.BCrypt;

namespace POS.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly POSContext _context;

    public UserRepository(POSContext context)
        => _context = context;

    private static User CreateUserDB(UserEntity entity)
    {
        var result = User.Create(entity.Id, entity.Username, entity.Email, entity.Phone,
            entity.Password, entity.Role);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.User;
    }
    public async Task<User> GetByIdAsync(Guid id)
    {
        var entity = await _context.Users
                         .AsNoTracking()
                         .FirstOrDefaultAsync(u => u.Id == id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"User not found");

        return CreateUserDB(entity);
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        var entities = await _context.Users
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No users found");

        return entities
            .Select(CreateUserDB)
            .ToList();
    }

    public async Task AddAsync(RegisterEntity model)
    {
        var (user, error) = User.Create(Guid.NewGuid(),model.Username, model.Email, model.Phone, 
            model.Password, model.Role);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest,error);
        
        var existingUserByEmail = await _context.Users
            .AsNoTracking()
            .AnyAsync(u => u.Email == user.Email);
        
        var existingUserByPhone = await _context.Users
            .AsNoTracking()
            .AnyAsync(u => u.Phone == user.Phone);
        
        if (existingUserByEmail || existingUserByPhone)
            throw new MyAuthException(AuthErrorTypes.CredentialsAlreadyExists, $"User with the same {(existingUserByEmail ? "email" : "phone")} already exists");

        var entity = new UserEntity
        {
            Username = user.Username,
            Email = user.Email,
            Phone = user.Phone,
            Password = HashPassword(user.Password),
            Role = user.Role
        };
        
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();

    }

    public async Task Remove(User model)
    {
        var entity = await _context.Users.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"User not found");

        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User model)
    {
        var entity = await _context.Users.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"User not found");

        entity.Username = model.Username;
        entity.Email = model.Email;
        entity.Phone = model.Phone;
        entity.Password = HashPassword(model.Password);
        entity.Role = model.Role;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<User>> FindAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        var entities = await _context.Users
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateUserDB)
            .ToList();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var entity = await _context.Users
                         .AsNoTracking()
                         .FirstOrDefaultAsync(u => u.Email == email)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"User not found");

        return CreateUserDB(entity);
    }

    public async Task<User?> GetByPhoneNumberAsync(string phone)
    {
        var entity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Phone == phone);

        return entity != null ? CreateUserDB(entity) : null;
    }
}