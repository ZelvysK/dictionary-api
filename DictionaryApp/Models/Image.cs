using DictionaryApp.Dtos;

namespace DictionaryApp.Models;

public class Image
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ImageDto ToDto() => new()
    {
        Id = Id,
        Name = Name
    };
}
