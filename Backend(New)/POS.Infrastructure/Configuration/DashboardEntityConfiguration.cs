using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Configuration;

public class DashboardEntityConfiguration : IEntityTypeConfiguration<DashboardEntity>
{
    public void Configure(EntityTypeBuilder<DashboardEntity> builder)
    {
        builder.HasKey(d => d.Id);
            
        builder.Property(d => d.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(500);
    }
}