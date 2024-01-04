using DictionaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp;

public class DictionaryContext(DbContextOptions<DictionaryContext> options) : DbContext(options)
{
    public DbSet<Entry> Entries { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder) {
    //}
}
