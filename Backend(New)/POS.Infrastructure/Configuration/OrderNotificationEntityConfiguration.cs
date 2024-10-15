using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class OrderNotificationEntityConfiguration : IEntityTypeConfiguration<OrderNotificationEntity>
{
    public void Configure(EntityTypeBuilder<OrderNotificationEntity> builder)
    {
        builder.HasKey(on => on.Id);

        builder.Property(on => on.Message)
            .HasMaxLength(OrderNotification.MAX_MESSAGE_LENGTH);

        builder.HasOne(on => on.Order)
            .WithMany(o => o.Notifications)
            .HasForeignKey(on => on.OrderId);
    }
}