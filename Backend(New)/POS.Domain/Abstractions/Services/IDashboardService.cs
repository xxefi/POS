using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IDashboardService
{
    Task<ICollection<Dashboard>> GetDashboardDataAsync();
}