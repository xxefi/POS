using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(User.MAX_USERNAME_LENGTH);
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(User.MAX_EMAIL_LENGTH);

        builder.Property(u => u.Phone)
            .IsRequired()
            .HasMaxLength(User.MAX_PHONE_LENGTH);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(User.MAX_PASSWORD_LENGTH);
        builder.Property(u => u.Role)
            .IsRequired()
            .HasConversion<string>();
    }
}
