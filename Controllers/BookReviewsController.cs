using LibraryApi.Dtos.Reviews;
using LibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/books/{bookId:guid}/reviews")]
public class BookReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;
    public BookReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview(Guid bookId, [FromBody] CreateReviewRequest createReviewRequest)
    {
        var result = await _reviewService.CreateReviewAsync(bookId, createReviewRequest);
        return result == null
            ? NotFound()
            : CreatedAtAction(nameof(ReviewsController.GetReviewByIdAsync), new { reviewId = result.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetByBookId(Guid bookId)
    {
        var result = await _reviewService.GetReviewByBookIdAsync(bookId);
        return result == null ? NotFound() : Ok(result);
    }
}
