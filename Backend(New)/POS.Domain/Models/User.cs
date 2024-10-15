using POS.Domain.Enums;

namespace POS.Domain.Models;

public class User
{
    public const int MAX_USERNAME_LENGTH = 50;
    public const int MAX_EMAIL_LENGTH = 100;
    public const int MAX_PHONE_LENGTH = 20;
    public const int MAX_PASSWORD_LENGTH = 100;
    
    private User(Guid id, string username, string email, string phone, string password, UserRole role)
    {
        Username = username;
        Email = email;
        Phone = phone;
        Password = password;
        Role = role;
    }
    public Guid Id { get;}
    public string Username { get; } 
    public string Email { get; } 
    public string Phone { get; } 
    public string Password { get; }
    public UserRole Role { get; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public static (User User, string Errors) Create(Guid id, string username, string email, string phone, string password, UserRole role)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(username) ||
                username.Length > MAX_USERNAME_LENGTH ? $"Username must be between 1 and {MAX_USERNAME_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(email) ||
                email.Length > MAX_EMAIL_LENGTH ? $"Email must be between 1 and {MAX_EMAIL_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(phone) ||
                phone.Length > MAX_PHONE_LENGTH ? $"Phone must be between 1 and {MAX_PHONE_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(password) ||
                password.Length > MAX_PASSWORD_LENGTH ? $"Password must be between 1 and {MAX_PASSWORD_LENGTH} characters" : null
            }
            .Where(e => e != null)
            .ToList();

        var user = new User(id, username, email, phone, password, role);
        return (user, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}