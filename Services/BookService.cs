using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Dtos.Books;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services;

public class BookService
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;

    public BookService(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookResponse>> GetAllBooksAsync()
    {
        var books = await _context.Books.ToListAsync();
        return _mapper.Map<List<BookResponse>>(books);
    }

    public async Task<BookResponse?> GetBookByIdAsync(Guid bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        return _mapper.Map<BookResponse>(book);
    }

    public async Task<BookResponse> CreateBookAsync(string title, string author, int yearOfPublication)
    {
        var book = new Book
        {
            Title = title,
            Author = author,
            YearOfPublication = yearOfPublication
        };
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        return _mapper.Map<BookResponse>(book);
    }

    public async Task<BookResponse?> UpdateBookAsync(Guid bookid, string title, string author, int yearOfPublication)
    {
        var book = await _context.Books.FindAsync(bookid);
        if(book == null) return null;
        book.Title = title;
        book.Author = author;
        book.YearOfPublication = yearOfPublication;
        await _context.SaveChangesAsync();
        return _mapper.Map<BookResponse>(book);
    }

    public async Task<bool> DeleteBookAsync(Guid bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book==null) return false;
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }


}