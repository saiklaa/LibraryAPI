using LibraryApi.Models;
using LibraryApi.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Title)
        .IsRequired().HasMaxLength(ValidationConstants.TitleMaxLength);
        builder.Property(b => b.Author)
        .IsRequired().HasMaxLength(ValidationConstants.AuthorMaxLength);
        builder.Property(b => b.YearOfPublication).IsRequired();
        
        builder.HasMany(book => book.Reviews)
               .WithOne(review => review.Book)
               .HasForeignKey(review => review.BookId)
               .OnDelete(DeleteBehavior.Cascade);


    }
}