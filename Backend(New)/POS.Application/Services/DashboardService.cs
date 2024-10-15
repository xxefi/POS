using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Models;

namespace POS.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _dashboardRepository;

    public DashboardService(IDashboardRepository dashboardRepository)
        => _dashboardRepository = dashboardRepository;
    
    public async Task<ICollection<Dashboard>> GetDashboardDataAsync()
    {
        return await _dashboardRepository.GetDashboardDataAsync();
    }
}