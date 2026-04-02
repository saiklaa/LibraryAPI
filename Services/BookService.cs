using System.Runtime.InteropServices;
using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Data.Books;
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

    public async Task<List<BookResponse>> GetAllBooksAsync(BooksFilterParameters filter)
    {
        var query = _context.Books.AsQueryable() //Select * From Booksn  
        .Include(b => b.Reviews)
        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Title))
        {
            query = query.Where(b => b.Title.Contains(filter.Title));
        }
        
        if (!string.IsNullOrWhiteSpace(filter.Author))
        {
            query = query.Where(b => b.Author.Contains(filter.Author));
        }

        if (filter.ReadingStatus.HasValue)
        {
            query = query.Where(b => b.ReadingStatus == filter.ReadingStatus.Value);
        }

        if (filter.MinRating.HasValue)
        {
            query = query.Where(b => b.Reviews.Any() 
                ? b.Reviews.Average(reviews => reviews.Rating) >= filter.MinRating.Value
                : false);
        }

        var books = await query.ToListAsync();
        return _mapper.Map<List<BookResponse>>(books);
    }




    public async Task<BookResponse?> GetBookByIdAsync(Guid bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        return _mapper.Map<BookResponse>(book);
    }

    public async Task<BookResponse> CreateBookAsync(CreateBookRequest createBookRequest)
    {
        
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