namespace POS.Domain.Models;

public class Account
{
    public const int MAX_USERNAME_LENGTH = 50;
    public const int MAX_EMAIL_LENGTH = 100;
    public const int MAX_PASSWORD_LENGTH = 100;

    private Account(Guid id, string username, string email, string password)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
    }

    public Guid Id { get; }
    public string Username { get; }
    public string Email { get; }
    public string Password { get; }

    public static (Account Account, string Error) Create(Guid id, string username, string email, string password)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(username) || username.Length > MAX_USERNAME_LENGTH ? $"Username must be between 1 and {MAX_USERNAME_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(email) || email.Length > MAX_EMAIL_LENGTH ? $"Email must be between 1 and {MAX_EMAIL_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(password) || password.Length > MAX_PASSWORD_LENGTH ? $"Password must be between 1 and {MAX_PASSWORD_LENGTH} characters" : null
            }
            .Where(e => e != null)
            .ToList();

        var account = new Account(id, username, email, password);
        return (account, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}