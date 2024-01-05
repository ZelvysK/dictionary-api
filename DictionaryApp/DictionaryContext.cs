using DictionaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp;

public class DictionaryContext(DbContextOptions<DictionaryContext> options) : DbContext(options)
{
    public DbSet<Entry> Entries { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Book> Books { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder) {
    //}
}
