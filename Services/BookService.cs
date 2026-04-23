using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Data.Books;
using LibraryApi.Dtos.Books;
using LibraryApi.Models;
using LibraryApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services;

public class BookService : IBookService
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
        var query = _context.Books
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
        query = filter.SortBy?.ToLower() switch
        {   
            "title"  => query.OrderBy(b => b.Title),
            "year"   => query.OrderBy(b => b.YearOfPublication),
            "rating" => query.OrderByDescending(b =>
                        b.Reviews.Any() ? b.Reviews.Average(r => r.Rating) : 0),
            _=> query.OrderBy(b => b.Title)
};

        var books = await query.ToListAsync();
        return _mapper.Map<List<BookResponse>>(books);
    }


    public async Task<BookDetailsResponse?> GetBookByIdAsync(Guid bookId)
    {
        var book = await _context.Books
            .Include(b => b.Reviews)
            .FirstOrDefaultAsync(b => b.Id ==bookId);
        return book == null ? null : _mapper.Map<BookDetailsResponse>(book);
    }
    
    public async Task<BookResponse> CreateBookAsync(CreateBookRequest createBookRequest)
    {
        var book = _mapper.Map<Book>(createBookRequest);
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return _mapper.Map<BookResponse>(book);

    }
    public async Task<BookResponse?> UpdateBookAsync(Guid bookId, UpdateBookRequest updateBookRequest)
    {
        var book = await _context.Books
            .Include(b => b.Reviews)
            .FirstOrDefaultAsync(b => b.Id == bookId);
        if (book == null) return null;
        _mapper.Map(updateBookRequest, book);
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