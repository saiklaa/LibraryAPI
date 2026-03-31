using LibraryApi.Dtos.Books;

namespace LibraryApi.Services.Interfaces;

public interface IBookService
{
    public Task<List<BookResponse>> GetAllBooksAsync();
    public Task<BookResponse?> GetBookByIdAsync(Guid bookId);
    public Task<BookResponse> CreateBookAsync(string title, string author, int yearOfPublication);
    public Task<BookResponse> UpdateBookAsync(string title, string author, int yearOfPublication, Guid bookId);
    public Task<BookResponse> DeleteBookAsync(Guid bookId);


}