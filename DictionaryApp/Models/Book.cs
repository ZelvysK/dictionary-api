using DictionaryApp.Controllers;
using DictionaryApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Author Author { get; set; }
    public Guid AuthorId { get; set; }
    public DateTime DateWritten { get; set; }
    public string CoverImageUrl { get; set; }

    public BookDto ToDto(DictionaryContext context) => new()
    {
        Id = Id,
        Title = Title,
        Description = Description,
        AuthorId = AuthorId,
        Author = context.Authors.Where(a => a.Id == AuthorId).Select(a => a.ToDto()).FirstOrDefault(),
        DateWritten = DateWritten,
        CoverImageUrl = CoverImageUrl
    };
}
