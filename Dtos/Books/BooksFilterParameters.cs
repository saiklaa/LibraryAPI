using LibraryApi.Models;

namespace LibraryApi.Dtos.Books;

public record BooksFilterParameters
{
    public string? Title { get; init; }
    public string? Author { get; init; } 
    public ReadingStatus? ReadingStatus { get; init; }
    public double? MinRating { get; init; } 
    public string? SortBy { get; init; } 
}   