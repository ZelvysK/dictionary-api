using DictionaryApp.Dtos;
using DictionaryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApp.Controllers;

[ApiController]
[Route("[controller]")]
public class EntryController(IEntryService entryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<EntryDto[]>> GetAllEntries() {
        var entries = await entryService.GetAllEntriesAsync();

        return Ok(entries);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<EntryDto[]>> GetEntryById(Guid id) {
        var entry = await entryService.GetEntryByIdAsync(id);

        if (entry is null)
        {
            return NotFound();
        }

        return Ok(entry);
    }
}
