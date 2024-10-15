namespace POS.Domain.Models;

public class Customer
{
    public const int MAX_NAME_LENGTH = 100;

    private Customer(Guid id, string fullName, string email, string phoneNumber)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
        
    public Guid Id { get; }
    public string FullName { get; }
    public string Email { get; }
    public string PhoneNumber { get; }

    public static (Customer Customer, string Errors) Create(Guid id, string fullName, string email, string phoneNumber)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(fullName) ? "Full name cannot be empty" : null,
                fullName.Length > MAX_NAME_LENGTH ? $"Full name cannot exceed {MAX_NAME_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(email) ? "Email cannot be empty" : null,
                string.IsNullOrWhiteSpace(phoneNumber) ? "Phone number cannot be empty" : null
            }
            .Where(e => e != null)
            .ToList();

        var customer = new Customer(id, fullName, email, phoneNumber);
        return (customer, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}