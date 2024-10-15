using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Configuration;

public class ReceiptEntityConfiguration : IEntityTypeConfiguration<ReceiptEntity>
{
    public void Configure(EntityTypeBuilder<ReceiptEntity> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.Property(r => r.TotalAmount)
            .IsRequired();

        builder.Property(r => r.OrderId)
            .IsRequired();

        builder.HasOne(r => r.Order)
            .WithMany(o => o.Receipts)
            .HasForeignKey(r => r.OrderId);
    }
}