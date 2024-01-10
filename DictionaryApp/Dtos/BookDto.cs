namespace DictionaryApp.Dtos;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AuthorDto? Author { get; set; }
    public Guid AuthorId { get; set; }
    public DateTime DateWritten { get; set; }
    public string CoverImageUrl { get; set; }
}
