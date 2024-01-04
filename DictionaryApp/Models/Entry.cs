using DictionaryApp.Dtos;

namespace DictionaryApp.Models;

public class Entry
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public EntryDto ToDto() => new()
    {
        Id = Id,
        Name = Name,
        Description = Description
    };
}
