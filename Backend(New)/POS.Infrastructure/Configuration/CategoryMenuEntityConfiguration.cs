using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class CategoryMenuEntityConfiguration : IEntityTypeConfiguration<CategoryMenuEntity>
{
    public void Configure(EntityTypeBuilder<CategoryMenuEntity> builder)
    {
        builder.HasKey(cm => cm.Id);

        builder.Property(cm => cm.Name)
            .IsRequired()
            .HasMaxLength(CategoryMenu.MAX_NAME_LENGTH);
        
        builder.Property(cm => cm.Description)
            .HasMaxLength(CategoryMenu.MAX_DESCRIPTION_LENGTH);
    }
}