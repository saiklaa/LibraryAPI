using LibraryApi.Dtos.Reviews;

namespace LibraryApi.Services.Interfaces;

public interface IReviewService
{
    public Task<List<ReviewResponse>> GetAllReviewsAsync();
    public Task<ReviewResponse?> GetReviewByIdAsync(Guid reviewId);
    public Task<ReviewResponse> CreateReviewAsync(string userName, int rating, string comment, Guid bookId);
    public Task<ReviewResponse> UpdateReviewAsync(string userName, int rating, string comment, Guid bookId, Guid reviewId);
    public Task<ReviewResponse> DeleteReviewAsync(Guid reviewId);
    public Task<List<ReviewResponse>> GetReviewByBookIdAsync(Guid bookId);

}