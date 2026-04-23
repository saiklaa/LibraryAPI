using LibraryApi.Dtos.Reviews;
using LibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;
    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _reviewService.GetAllReviewsAsync();
        return Ok(result);
    }

    [HttpGet("{reviewId:guid}")]
    public async Task<IActionResult> GetReviewByIdAsync(Guid reviewId)
    {
        var review = await _reviewService.GetReviewByIdAsync(reviewId);
        return review == null ? NotFound() : Ok(review);
    }

    [HttpDelete("{reviewId:guid}")]
    public async Task<IActionResult> DeleteReview(Guid reviewId)
    {
        var result = await _reviewService.DeleteReviewAsync(reviewId);
        return result == false ? NotFound() : NoContent();
    }
}