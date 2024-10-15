using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class AccountEntityConfiguration : IEntityTypeConfiguration<AccountEntity>
{
    public void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Username)
            .IsRequired()
            .HasMaxLength(Account.MAX_USERNAME_LENGTH);

        builder.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(Account.MAX_EMAIL_LENGTH);

        builder.Property(a => a.Password)
            .IsRequired()
            .HasMaxLength(Account.MAX_PASSWORD_LENGTH);

        builder.HasOne<CustomerEntity>()
            .WithMany()
            .HasForeignKey(a => a.CustomerId);
    }
}