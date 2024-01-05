using DictionaryApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp.Services;

public interface IEntryService
{
    Task<EntryDto[]> GetAllEntriesAsync();
    Task<AuthorDto[]> GetAllAuthorsAsync();
    Task<ImageDto[]> GetAllImagesAsync();

    Task<EntryDto?> GetEntryByIdAsync(Guid id);
    Task<AuthorDto?> GetAuthorByIdAsync(Guid id);
    Task<ImageDto?> GetImageByIdAsync(Guid id);
}

public class EntryService(DictionaryContext context, ILogger<EntryService> logger) : IEntryService
{

    public async Task<EntryDto[]> GetAllEntriesAsync() {
        logger.LogInformation("Get all entries");

        var entries = await context.Entries.AsNoTracking().ToArrayAsync();

        var result = entries.Select(e => e.ToDto()).ToArray();

        return result;
    }
    public async Task<EntryDto?> GetEntryByIdAsync(Guid id) {
        logger.LogInformation("Get entry by id: {id}", id);

        var entry = await context.Entries.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        var result = entry?.ToDto();

        return result;
    }

    public async Task<AuthorDto[]> GetAllAuthorsAsync() {
        logger.LogInformation("Get all entries");

        var entries = await context.Authors.AsNoTracking().ToArrayAsync();

        var result = entries.Select(e => e.ToDto()).ToArray();

        return result;
    }
    public async Task<AuthorDto?> GetAuthorByIdAsync(Guid id) {
        logger.LogInformation("Get entry by id: {id}", id);

        var entry = await context.Authors.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        var result = entry?.ToDto();

        return result;
    }

    public async Task<ImageDto[]> GetAllImagesAsync() {
        logger.LogInformation("Get all entries");

        var entries = await context.Images.AsNoTracking().ToArrayAsync();

        var result = entries.Select(e => e.ToDto()).ToArray();

        return result;
    }
    public async Task<ImageDto?> GetImageByIdAsync(Guid id) {
        logger.LogInformation("Get entry by id: {id}", id);

        var entry = await context.Images.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        var result = entry?.ToDto();

        return result;
    }
}
