using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Configuration;

namespace POS.Infrastructure.Context;

public class POSContext : DbContext
{
    public POSContext(DbContextOptions<POSContext> options)
        : base(options)
    {
    }

    public DbSet<CashierEntity> Cashiers { get; set; }
    public DbSet<InventoryEntity> Inventories { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<PaymentEntity> Payments { get; set; }
    public DbSet<TableEntity> Tables { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<MenuItemEntity> MenuItems { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<InventoryItemEntity> InventoryItems { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<FeedbackEntity> Feedbacks { get; set; }
    public DbSet<CategoryMenuEntity> CategoryMenus { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<GeneralSettingsEntity> GeneralSettings { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<SaleEntity> Sales { get; set; }
    public DbSet<StatisticsEntity> Statistics { get; set; }
    public DbSet<TerminalEntity> Terminals { get; set; }
    public DbSet<TerminalSettingsEntity> TerminalSettings { get; set; }
    public DbSet<OrderNotificationEntity> OrderNotifications { get; set; }
    public DbSet<ReceiptEntity> Receipts { get; set; }
    public DbSet<RefundEntity> Refunds { get; set; }
    public DbSet<DashboardEntity> Dashboards { get; set; }
    public DbSet<ReportEntity> Reports { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MenuItemEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CashierEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TableEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new MenuItemEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryMenuEntityConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientEntityConfiguration());
        modelBuilder.ApplyConfiguration(new GeneralSettingsEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SaleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StatisticsEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TerminalEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TerminalSettingsEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderNotificationEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReceiptEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DashboardEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReportEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AccountEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}