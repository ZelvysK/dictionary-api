using DictionaryApp.Dtos;
using DictionaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp.Services;

public interface IBookService
{
    Task<BookDto[]> GetAllBooksAsync();
    Task<IEnumerable<BookDto>> GetBookByAuthorAsync(Guid author);
    Task<BookDto?> GetBookByIdAsync(Guid id);
}

public class BookService(DictionaryContext context, ILogger<BookService> logger) : IBookService
{
    public async Task<BookDto[]> GetAllBooksAsync() {
        logger.LogInformation("Get all entries");

        var entries = await context.Books.AsNoTracking().ToArrayAsync();

        var result = entries.Select(e => e.ToDto(context)).ToArray();

        return result;
    }
    public async Task<BookDto?> GetBookByIdAsync(Guid id) {
        logger.LogInformation("Get entry by id: {id}", id);

        var entry = await context.Books.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        var result = entry?.ToDto(context);

        return result;
    }
    public async Task<IEnumerable<BookDto>> GetBookByAuthorAsync(Guid authorId) {
        logger.LogInformation("Get entry by author: {authorId}", authorId);

        var entry = await context.Books.AsNoTracking().Where(a => a.AuthorId == authorId).ToListAsync();

        var result = entry?.Select(b => b.ToDto(context));

        return result;
    }
}
