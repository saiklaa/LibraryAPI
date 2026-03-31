using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Dtos.Reviews;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services;

public class ReviewService
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;
    public ReviewService(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ReviewResponse>> GetAllReviewAsync()
    {
        var reviews = await _context.Reviews.ToListAsync();
        return _mapper.Map<List<ReviewResponse>>(reviews);
    }

    public async Task<ReviewResponse?> GetReviewByIdAsync(Guid reviewId)
    {
        var review = await _context.Reviews.FindAsync(reviewId);
        return _mapper.Map<ReviewResponse>(review);
    }

    public async Task<ReviewResponse> CreateReviewAsync(Guid bookId, string userName, int rating, string comment)
    {
        var review = new Review
        {
            BookId = bookId,
            UserName = userName,
            Rating = rating,
            Comment = comment
        };
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return _mapper.Map<ReviewResponse>(review);
    }

    public async Task<bool> DeleteReviewAsync(Guid reviewId)
    {
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null) return false;
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ReviewResponse>> GetReviewByBookIdAsync(Guid bookId)
    {
        var reviews =  await _context.Reviews
            .Where(review => review.BookId == bookId)
            .ToListAsync();
        return _mapper.Map<List<ReviewResponse>>(reviews);
    }

    

}