using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Configuration;

public class TerminalEntityConfiguration : IEntityTypeConfiguration<TerminalEntity>
{
    public void Configure(EntityTypeBuilder<TerminalEntity> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.TerminalName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(t => t.Location)
            .HasMaxLength(255);
    }
}