using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options ?? throw new ArgumentNullException(nameof(options))) {
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookAuthors> BookAuthors { get; set; }
    public virtual DbSet<BookList> BookLists { get; set; }
    public virtual DbSet<BookListBooks> BookListBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<BookAuthors>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder
            .Entity<BookAuthors>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);
        
        modelBuilder
            .Entity<BookAuthors>()
            .HasOne(ba => ba.Author)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder
            .Entity<BookListBooks>()
            .HasOne(blb => blb.BookList)
            .WithMany(bl => bl.BookListBooks)
            .HasForeignKey(blb => blb.BookListId);
        
        modelBuilder
            .Entity<BookListBooks>()
            .HasOne(blb => blb.Book)
            .WithMany(bl => bl.BookListBooks)
            .HasForeignKey(blb => blb.BookId);
    }
}