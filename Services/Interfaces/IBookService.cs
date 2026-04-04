using LibraryApi.Data.Books;
using LibraryApi.Dtos.Books;

namespace LibraryApi.Services.Interfaces;

public interface IBookService
{
    public Task<List<BookResponse>> GetAllBooksAsync(BooksFilterParameters filter);
    public Task<BookDetailsResponse?> GetBookByIdAsync(Guid bookId);
    public Task<BookResponse> CreateBookAsync(CreateBookRequest createBookRequest);
    public Task<BookResponse?> UpdateBookAsync(Guid bookId, UpdateBookRequest updateBookRequest);
    public Task<bool> DeleteBookAsync(Guid bookId);


}