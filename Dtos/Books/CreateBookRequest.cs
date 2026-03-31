namespace LibraryApi.Dtos.Books;

public record CreateBookRequest(
    string Title,
    string Author,
    int YearOfPublication
 );