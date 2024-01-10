using DictionaryApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp.Services;

public interface IAuthorService
{
    Task<AuthorDto[]> GetAllAuthorsAsync();
    Task<AuthorDto?> GetAuthorByIdAsync(Guid id);
}

public class AuthorService(DictionaryContext context, ILogger<EntryService> logger) : IAuthorService
{
    public async Task<AuthorDto[]> GetAllAuthorsAsync() {
        logger.LogInformation("Get all authors");

        var entries = await context.Authors
            .AsNoTracking()
            .ToArrayAsync();

        var result = entries.Select(e => e.ToDto()).ToArray();

        return result;
    }
    public async Task<AuthorDto?> GetAuthorByIdAsync(Guid id) {
        logger.LogInformation("Get author by id: {id}", id);

        var entry = await context.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        var result = entry?.ToDto();

        return result;
    }
}
