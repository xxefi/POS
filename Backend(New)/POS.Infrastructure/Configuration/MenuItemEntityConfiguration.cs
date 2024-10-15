using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class MenuItemEntityConfiguration : IEntityTypeConfiguration<MenuItemEntity>
{
    public void Configure(EntityTypeBuilder<MenuItemEntity> builder)
    {
        builder.HasKey(mi => mi.Id);
        builder.Property(mi => mi.Name)
            .IsRequired()
            .HasMaxLength(MenuItem.MAX_NAME_LENGTH);
        
        builder.Property(m => m.Description)
            .HasMaxLength(MenuItem.MAX_DESCRIPTION_LENGTH);
        builder.Property(m => m.Price)
            .IsRequired();
    }
}
