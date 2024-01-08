using DictionaryApp.Dtos;
using DictionaryApp.Models;
using DictionaryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookControler(IEntryService entryService, IBookService bookService) : ControllerBase
{
    [HttpGet("Authors")]
    public async Task<ActionResult<AuthorDto[]>> GetAllAuthors() {
        var entries = await entryService.GetAllAuthorsAsync();

        return Ok(entries);
    }
    [HttpGet("Authors/{id}")]
    public async Task<ActionResult<AuthorDto[]>> GetAuthorById(Guid id) {
        var entry = await entryService.GetAuthorByIdAsync(id);

        if (entry is null)
        {
            return NotFound();
        }

        return Ok(entry);
    }

    [HttpGet("Books")]
    public async Task<ActionResult<BookDto[]>> GetAllBooks() {
        var entries = await bookService.GetAllBooksAsync();

        return Ok(entries);
    }
    [HttpGet("Books/{id}")]
    public async Task<ActionResult<BookDto[]>> GetBookById(Guid id) {
        var entry = await bookService.GetBookByIdAsync(id);

        if (entry is null)
        {
            return NotFound();
        }

        return Ok(entry);
    }
    [HttpGet("Books/Author{authorId}")]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBookByAuthor(Guid authorId) {
        var entry = await bookService.GetBookByAuthorAsync(authorId);

        if (entry is null || !entry.Any())
        {
            return NotFound();
        }

        return Ok(entry);
    }
}
