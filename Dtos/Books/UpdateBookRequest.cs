using LibraryApi.Models;

namespace LibraryApi.Dtos.Books;
public record UpdateBookRequest(
    string Title,
    string Author,
    int YearOfPublication,
    ReadingStatus ReadingStatus
);
