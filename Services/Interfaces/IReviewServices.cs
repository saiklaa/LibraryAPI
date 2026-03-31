using LibraryApi.Dtos.Reviews;

namespace LibraryApi.Services.Interfaces;

public interface IReviewService
{
    public Task<List<ReviewResponse>> GetAllReviewsAsync();
    public Task<ReviewResponse?> GetReviewByIdAsync(Guid reviewId);
    public Task<ReviewResponse> CreateReviewAsync(Guid bookId, string userName, int rating, string comment);
    public Task<bool> DeleteReviewAsync(Guid reviewId);
    public Task<List<ReviewResponse>> GetReviewByBookIdAsync(Guid bookId);

}