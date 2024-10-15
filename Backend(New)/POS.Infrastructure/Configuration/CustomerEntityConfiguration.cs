using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FullName)
            .IsRequired()
            .HasMaxLength(Customer.MAX_NAME_LENGTH);
        builder.Property(c => c.Email)
            .HasMaxLength(100);
        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(20);
    }
}