using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class TerminalSettingsEntityConfiguration : IEntityTypeConfiguration<TerminalSettingsEntity>
{
    public void Configure(EntityTypeBuilder<TerminalSettingsEntity> builder)
    {
        builder.HasKey(ts => ts.Id);

        builder.Property(ts => ts.SettingKey)
            .IsRequired()
            .HasMaxLength(TerminalSettings.MAX_KEY_LENGTH);
        builder.Property(ts => ts.SettingValue)
            .IsRequired()
            .HasMaxLength(TerminalSettings.MAX_VALUE_LENGTH);

        builder.HasOne(ts => ts.Terminal)
            .WithMany(t => t.Settings)
            .HasForeignKey(ts => ts.TerminalId);
    }
}