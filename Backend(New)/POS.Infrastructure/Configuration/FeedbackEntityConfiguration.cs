using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Infrastructure.Configuration;

public class FeedbackEntityConfiguration : IEntityTypeConfiguration<FeedbackEntity>
{
    public void Configure(EntityTypeBuilder<FeedbackEntity> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Comment)
            .HasMaxLength(Feedback.MAX_COMMENT_LENGTH);
        builder.Property(f => f.Rating)
            .IsRequired()
            .HasMaxLength(Feedback.MAX_RATING);

        builder.HasOne(f => f.Customer)
            .WithMany(c => c.Feedbacks)
            .HasForeignKey(f => f.CustomerId);
    }
}