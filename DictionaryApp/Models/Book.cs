using DictionaryApp.Dtos;

namespace DictionaryApp.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Author? Author { get; set; }
    public Guid AuthorId { get; set; }
    public DateTime DateWritten { get; set; }
    public string CoverImageUrl { get; set; }

    public BookDto ToDto() => new()
    {
        Id = Id,
        Title = Title,
        Description = Description,
        AuthorId = AuthorId,
        Author = Author?.ToDto(),
        DateWritten = DateWritten,
        CoverImageUrl = CoverImageUrl
    };
}
