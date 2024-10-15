namespace POS.Domain.Models;

public class Cashier
{
    public const int MAX_NAME_LENGTH = 100;

    private Cashier(Guid id, string name, string email, string phone, string pinCode, string brand)
    {
        Id = id;
        Name = name;
        Email = email; 
        Phone = phone;
        PinCode = pinCode;
        Brand = brand;
    }

    public Guid Id { get; }
    public string Name { get; } 
    public string Email { get; }
    public string Phone { get; } 
    public string PinCode { get; }
    public string Brand { get; }

    public static (Cashier Cashier, string Errors) Create(Guid id, string name, string email, string phone, string pinCode, string brand)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(name) ? "Name cannot be empty" : null,
                name.Length > MAX_NAME_LENGTH ? $"Name cannot exceed {MAX_NAME_LENGTH} characters" : null,
                string.IsNullOrWhiteSpace(email) ? "Email cannot be empty" : null,
                string.IsNullOrWhiteSpace(phone) ? "Phone cannot be empty" : null,
            }
            .Where(e => e != null).ToList();

        var cashier = new Cashier(id, name, email, phone, pinCode, brand);
        return (cashier, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}