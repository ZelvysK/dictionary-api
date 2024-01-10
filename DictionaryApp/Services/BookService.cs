using DictionaryApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp.Services;

public interface IBookService
{
    Task<BookDto[]> GetAllBooksAsync();
    Task<BookDto[]> GetBooksByAuthorAsync(Guid author);
    Task<BookDto?> GetBookWithAuthorByIdAsync(Guid id);
}

public class BookService(DictionaryContext context, ILogger<BookService> logger) : IBookService
{
    public async Task<BookDto[]> GetAllBooksAsync() {
        logger.LogInformation("Get all entries");

        var entries = await context.Books
            .AsNoTracking()
            .ToArrayAsync();

        var result = entries.Select(e => e.ToDto()).ToArray();

        return result;
    }

    public async Task<BookDto?> GetBookWithAuthorByIdAsync(Guid id) {
        logger.LogInformation("Get entry by id: {id}", id);

        var entry = await context.Books
            .AsNoTracking()
            .Include(a => a.Author)
            .FirstOrDefaultAsync(e => e.Id == id);

        var result = entry?.ToDto();

        return result;
    }

    public async Task<BookDto[]> GetBooksByAuthorAsync(Guid authorId) {
        logger.LogInformation("Get entry by author: {authorId}", authorId);

        var entries = await context.Books
            .AsNoTracking()
            .Where(a => a.AuthorId == authorId)
            .ToArrayAsync();

        var result = entries.Select(b => b.ToDto()).ToArray();

        return result;
    }
}
