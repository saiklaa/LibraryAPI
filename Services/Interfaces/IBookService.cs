using LibraryApi.Dtos.Books;

namespace LibraryApi.Services.Interfaces;

public interface IBookService
{
    Task<List<BookResponse>> GetAllBooksAsync(BooksFilterParameters filter);
    Task<BookDetailsResponse?> GetBookByIdAsync(Guid bookId);
    Task<BookResponse> CreateBookAsync(CreateBookRequest createBookRequest);
    Task<BookResponse?> UpdateBookAsync(Guid bookId, UpdateBookRequest updateBookRequest);
    Task<bool> DeleteBookAsync(Guid bookId);


}