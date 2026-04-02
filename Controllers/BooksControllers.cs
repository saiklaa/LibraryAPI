using LibraryApi.Data.Books;
using LibraryApi.Dtos.Books;
using LibraryApi.Models;
using LibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksControllers : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IReviewService _reviewService;

    public BooksControllers(IBookService bookService, IReviewService reviewService)
    {
        _bookService = bookService;
        _reviewService = reviewService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooks(
    [FromQuery] BooksFilterParameters filter
    )
    {
        var books = await _bookService.GetAllBooksAsync(filter);
        return Ok(books);
    }

}
