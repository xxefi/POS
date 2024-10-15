using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class GeneralSettingsEntityConfiguration : IEntityTypeConfiguration<GeneralSettingsEntity>
{
    public void Configure(EntityTypeBuilder<GeneralSettingsEntity> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Key)
            .IsRequired()
            .HasMaxLength(GeneralSettings.MAX_KEY_LENGTH);
        builder.Property(g => g.Value)
            .IsRequired()
            .HasMaxLength(GeneralSettings.MAX_VALUE_LENGTH);
    }
}