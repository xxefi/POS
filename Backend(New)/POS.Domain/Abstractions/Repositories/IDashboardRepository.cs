
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IDashboardRepository
{
    Task<ICollection<Dashboard>> GetDashboardDataAsync();
}
