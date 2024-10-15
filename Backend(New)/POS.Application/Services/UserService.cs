using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
        => _userRepository = userRepository;
    
    public async Task<ICollection<User>> GetUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User> CreateUserAsync(RegisterEntity user)
    {
        await _userRepository.AddAsync(user);
        return await _userRepository.GetByEmailAsync(user.Email);
    }
}