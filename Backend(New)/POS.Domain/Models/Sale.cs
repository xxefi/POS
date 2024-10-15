namespace POS.Domain.Models;

public class Sale
{
    private Sale(Guid id, DateTime saleDate, decimal totalAmount)
    {
        Id = id;
        SaleDate = saleDate;
        TotalAmount = totalAmount;
    }

    public Guid Id { get; }
    public DateTime SaleDate { get; }
    public decimal TotalAmount { get; }

    public static (Sale Sale, string Errors) Create(Guid id, DateTime saleDate, decimal totalAmount)
    {
        var errors = new List<string>
            {
                saleDate > DateTime.UtcNow ? "Sale date cannot be in the future" : null,
                totalAmount <= 0 ? "Total amount must be greater than 0" : null
            }
            .Where(e => e != null)
            .ToList();

        var sale = new Sale(id, saleDate, totalAmount);
        return (sale, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}