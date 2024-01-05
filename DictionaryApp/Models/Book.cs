using DictionaryApp.Dtos;

namespace DictionaryApp.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Author Author { get; set; }
    public DateTime DateWritten { get; set; }
    public Image CoverImage { get; set; }

    public BookDto ToDto() => new()
    {
        Id = Id,
        Title = Title,
        Description = Description,
        Author = Author.ToDto(),
        DateWritten = DateWritten,
        CoverImage = CoverImage.ToDto()
    };
}
