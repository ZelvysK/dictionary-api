using DictionaryApp.Dtos;
using DictionaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp.Services;

public interface IBookService
{
    Task<BookDto[]> GetAllBooksAsync();
    Task<BookDto?> GetBookByAuthorAsync(Author author);
    Task<BookDto?> GetBookByIdAsync(Guid id);
}

public class BookService(DictionaryContext context, ILogger<BookService> logger) : IBookService
{
    public async Task<BookDto[]> GetAllBooksAsync() {
        logger.LogInformation("Get all entries");

        var entries = await context.Books.AsNoTracking().ToArrayAsync();

        var result = entries.Select(e => e.ToDto()).ToArray();

        return result;
    }
    public async Task<BookDto?> GetBookByIdAsync(Guid id) {
        logger.LogInformation("Get entry by id: {id}", id);

        var entry = await context.Books.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        var result = entry?.ToDto();

        return result;
    }
    public async Task<BookDto?> GetBookByAuthorAsync(Author author) {
        logger.LogInformation("Get entry by author: {author}", author);

        var entry = await context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Author == author);

        var result = entry?.ToDto();

        return result;
    }
}
