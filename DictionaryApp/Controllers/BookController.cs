using DictionaryApp.Dtos;
using DictionaryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<BookDto[]>> GetAllBooks() {
        var entries = await bookService.GetAllBooksAsync();

        return Ok(entries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto[]>> GetBookById(Guid id) {
        var entry = await bookService.GetBookWithAuthorByIdAsync(id);

        if (entry is null)
        {
            return NotFound();
        }

        return Ok(entry);
    }

    [HttpGet("Author/{authorId}")]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByAuthor(Guid authorId) {
        var entries = await bookService.GetBooksByAuthorAsync(authorId);

        return Ok(entries);
    }
}
