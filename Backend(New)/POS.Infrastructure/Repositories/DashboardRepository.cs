
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly POSContext _context;

    public DashboardRepository(POSContext context)
        => _context = context;

    private static Dashboard CreateDashboardDB(DashboardEntity dashboardEntity)
    {
        var result = Dashboard.Create(dashboardEntity.Id ,dashboardEntity.DateGenerated, dashboardEntity.TotalSales,
            dashboardEntity.TotalRevenue, dashboardEntity.Title, dashboardEntity.Description);
        
        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Dashboard;
    }
    
    public async Task<ICollection<Dashboard>> GetDashboardDataAsync()
    {
        var dashboardEntity = await _context.Dashboards
            .AsNoTracking()
            .ToListAsync();

        if (!dashboardEntity.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No dashboard data found");

        return dashboardEntity
            .Select(CreateDashboardDB)
            .ToList();

    }
}
