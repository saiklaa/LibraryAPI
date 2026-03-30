using LibraryApi.Dtos.Reviews;
using LibraryApi.Models;
namespace LibraryApi.Dtos.Books;

public record BookDetailsResponse(
    Guid Id,
    string Title,
    string Author,
    int YearOfPublication,
    ReadingStatus ReadingStatus,
    double AverageRating,
    int ReviewsCount,
    IReadOnlyList<ReviewResponse> Reviews  
);