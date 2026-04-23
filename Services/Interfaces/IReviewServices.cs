using LibraryApi.Dtos.Reviews;

namespace LibraryApi.Services.Interfaces;

public interface IReviewService
{
    Task<List<ReviewResponse>> GetAllReviewsAsync();
    Task<ReviewResponse?> GetReviewByIdAsync(Guid reviewId);
    Task<ReviewResponse?> CreateReviewAsync(Guid bookId, CreateReviewRequest createReviewRequest);
    Task<bool> DeleteReviewAsync(Guid reviewId);
    Task<List<ReviewResponse>?> GetReviewByBookIdAsync(Guid bookId);

}