using DictionaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp;

public class DictionaryContext(DbContextOptions<DictionaryContext> options) : DbContext(options)
{
    public DbSet<Entry> Entries { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //modelBuilder.Entity<Book>()
        //    .HasOne(b => b.Author)
        //    .WithMany()
        //    .HasForeignKey(b => b.AuthorId);
        ////.IsRequired()
        ////.OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Book>()
        //    .HasOne(b => b.CoverImage)
        //    .WithMany()
        //    .HasForeignKey(b => b.CoverImageId);
        //    //.IsRequired();

        ////modelBuilder.Entity<Book>()
        ////    .HasOne(b => b.CoverImage)
        ////    .WithMany()
        ////    .OnDelete(DeleteBehavior.NoAction);

        ////modelBuilder.Entity<Author>()
        ////    .HasOne(a => a.Photo)
        ////    .WithMany()
        ////    .HasForeignKey(a => a.PhotoId)
        ////    .IsRequired()
        ////    .OnDelete(DeleteBehavior.Restrict);
    }
}
