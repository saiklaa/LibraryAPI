using LibraryApi.Models;

namespace LibraryApi.Dtos.Books;

public record BookResponse(
    Guid Id,
    string Title,
    string Author,
    int YearOfPublication,
    ReadingStatus ReadingStatus,      
    double AverageRating,      
    int ReviewsCount           
);