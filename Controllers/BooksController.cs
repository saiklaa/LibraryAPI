using LibraryApi.Data.Books;
using LibraryApi.Dtos.Books;
using LibraryApi.Models;
using LibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BooksFilterParameters filter)
    {
        var books = await _bookService.GetAllBooksAsync(filter);
        return Ok(books);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest createBookRequest)
    {
        var bookResponse = await _bookService.CreateBookAsync(createBookRequest);
        return CreatedAtAction(nameof(GetById), new { id = bookResponse.Id }, bookResponse);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookRequest updateBookRequest)
    {
        var updateBook = await _bookService.UpdateBookAsync(id, updateBookRequest);

        return updateBook == null ? NotFound() : Ok(updateBook);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var result = await _bookService.DeleteBookAsync(id);
        return result == false ? NotFound() : NoContent();
    }
} 
