using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class InventoryEntityConfiguration : IEntityTypeConfiguration<InventoryEntity>
{
    public void Configure(EntityTypeBuilder<InventoryEntity> builder)
    {
        builder.HasKey(i => i.Id); 

        builder.Property(i => i.IngredientName)
            .IsRequired()
            .HasMaxLength(Inventory.MAX_INGREDIENT_NAME_LENGTH);

        builder.Property(i => i.Quantity)
            .IsRequired(); 
    }
}
