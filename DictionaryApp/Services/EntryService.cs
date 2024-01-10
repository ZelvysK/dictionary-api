using DictionaryApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp.Services;

public interface IEntryService
{
    Task<EntryDto[]> GetAllEntriesAsync();
    Task<EntryDto?> GetEntryByIdAsync(Guid id);
}

public class EntryService(DictionaryContext context, ILogger<EntryService> logger) : IEntryService
{
    public async Task<EntryDto[]> GetAllEntriesAsync() {
        logger.LogInformation("Get all entries");

        var entries = await context.Entries
            .AsNoTracking()
            .ToArrayAsync();

        var result = entries.Select(e => e.ToDto()).ToArray();

        return result;
    }

    public async Task<EntryDto?> GetEntryByIdAsync(Guid id) {
        logger.LogInformation("Get entry by id: {id}", id);

        var entry = await context.Entries
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        var result = entry?.ToDto();

        return result;
    }
}
