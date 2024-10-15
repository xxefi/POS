using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Configuration;

public class StatisticsEntityConfiguration : IEntityTypeConfiguration<StatisticsEntity>
{
    public void Configure(EntityTypeBuilder<StatisticsEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.ReportDate)
            .IsRequired();
        builder.Property(s => s.TotalSales)
            .IsRequired();
        builder.Property(s => s.TotalExpenses)
            .IsRequired();
    }
}