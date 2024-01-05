using DictionaryApp.Dtos;

namespace DictionaryApp.Models;

public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Image Photo { get; set; }

    public AuthorDto ToDto() => new()
    {
        Id = Id,
        FirstName = FirstName,
        LastName = LastName,
        Photo = Photo.ToDto()
    };
}

