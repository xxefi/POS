using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class InventoryItemEntityConfiguration : IEntityTypeConfiguration<InventoryItemEntity>
{
    public void Configure(EntityTypeBuilder<InventoryItemEntity> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(InventoryItem.MAX_NAME_LENGTH);
        builder.Property(i => i.Quantity)
            .IsRequired();
        builder.Property(i => i.UnitPrice)
            .IsRequired();
        builder.Property(i => i.ExpiryDate)
            .IsRequired();

        builder.HasOne(i => i.Inventory)
            .WithMany(inv => inv.InventoryItems)
            .HasForeignKey(i => i.InventoryId);
    }
}