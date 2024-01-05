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

    [HttpGet("Images")]
    public async Task<ActionResult<ImageDto[]>> GetAllImages() {
        var entries = await entryService.GetAllImagesAsync();

        return Ok(entries);
    }
    [HttpGet("Images/{id}")]
    public async Task<ActionResult<ImageDto[]>> GetImageById(Guid id) {
        var entry = await entryService.GetImageByIdAsync(id);

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
    [HttpGet("Books/{author}")]
    public async Task<ActionResult<BookDto[]>> GetBookByAuthor(Author author) {
        var entry = await bookService.GetBookByAuthorAsync(author);

        if (entry is null)
        {
            return NotFound();
        }

        return Ok(entry);
    }
}
