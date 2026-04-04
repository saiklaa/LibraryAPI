using LibraryApi.Dtos.Reviews;
using LibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ReviewsControllers : ControllerBase
{
    private readonly IReviewService _reviewService;
    public ReviewsControllers(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetReviewByIdAsync(Guid id)
    {
        var review = await _reviewService.GetReviewByIdAsync(id);
    
        return review == null ? NotFound() : Ok(review);
    }

    [HttpPost("books/{id:guid}/reviews")]
    public async Task<IActionResult> Create(Guid id, [FromBody] CreateReviewRequest createReviewRequest)
    {
        var result = await _reviewService.CreateReviewAsync(id, createReviewRequest);
        return result == null
        ? NotFound() 
        : CreatedAtAction(nameof(GetReviewByIdAsync), new {id = result.Id}, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        var result = await _reviewService.DeleteReviewAsync(id);
        return result == false ? NotFound() : NoContent();
    }

    [HttpGet("books/{bookId:guid}/reviews")]
    public async Task<IActionResult> GetByBookId(Guid bookId)
    {
        var result = await _reviewService.GetReviewByBookIdAsync(bookId);
        return result == null ? NotFound() : Ok(result);

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _reviewService.GetAllReviewsAsync();
        return Ok(result);
    }
}