using LibraryApi.Data.Books;
using LibraryApi.Dtos.Books;

namespace LibraryApi.Services.Interfaces;

public interface IBookService
{
    public Task<List<BookResponse>> GetAllBooksAsync(BooksFilterParameters filter);
    public Task<BookResponse?> GetBookByIdAsync(Guid bookId);
    public Task<BookResponse> CreateBookAsync(string title, string author, int yearOfPublication);
    public Task<BookResponse?> UpdateBookAsync(string title, string author, int yearOfPublication, Guid bookId);
    public Task<bool> DeleteBookAsync(Guid bookId);


}