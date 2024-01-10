using DictionaryApp.Dtos;
using DictionaryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<AuthorDto[]>> GetAllAuthors() {
        var entries = await authorService.GetAllAuthorsAsync();

        return Ok(entries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto[]>> GetAuthorById(Guid id) {
        var entry = await authorService.GetAuthorByIdAsync(id);

        if (entry is null)
        {
            return NotFound();
        }

        return Ok(entry);
    }

}
