using LibraryApi.Models;
using LibraryApi.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.BookId);
        builder.Property(r => r.UserName)
        .IsRequired().HasMaxLength(ValidationConstants.UserNameMaxLength);
        builder.Property(r => r.Rating)
        .IsRequired();
        builder.Property(r => r.Comment)
        .IsRequired().HasMaxLength(ValidationConstants.CommentMaxLength);
    }
}