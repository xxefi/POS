using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class CashierEntityConfiguration : IEntityTypeConfiguration<CashierEntity>
{
    public void Configure(EntityTypeBuilder<CashierEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(Cashier.MAX_NAME_LENGTH);
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(c => c.Phone)
            .IsRequired()
            .HasMaxLength(32);
    }
}