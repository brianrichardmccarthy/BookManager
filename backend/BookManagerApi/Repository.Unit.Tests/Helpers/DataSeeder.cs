using System.Diagnostics.CodeAnalysis;
using Bogus;
using Repository.Context;
using Repository.Models;

namespace Repository.Unit.Tests.Helpers;

[ExcludeFromCodeCoverage]
public class DataSeeder(ApplicationContext context) {
    public void Seed() {
        var authorFaker = new Faker<Author>()
                          .RuleFor(a => a.Name, f => f.Name.FullName())
                          .RuleFor(a => a.Bio, f => f.Lorem.Paragraph());
        var authors = authorFaker.Generate(10);

        var bookFaker = new Faker<Book>()
                          .RuleFor(b => b.Title, b => b.Lorem.Sentence(5));
        var books = bookFaker.Generate(30);

        var bookAuthorFaker = new Faker<BookAuthors>().CustomInstantiator(f => {
            var b = f.PickRandom(books);
            var a = f.PickRandom(authors);
            return new BookAuthors {
                Book = b,
                BookId = b.BookId,
                Author = a,
                AuthorId = a.AuthorId
            };
        });

        var bookAuthors = bookAuthorFaker.Generate(30);
        
        var bookListFaker = new Faker<BookList>().RuleFor(bl => bl.Name, f => f.Lorem.Sentence(5));
        var bookList = bookListFaker.Generate(5);

        var bookListBookFaker = new Faker<BookListBooks>().CustomInstantiator(f => {
            var b = f.PickRandom(books);
            var bl = f.PickRandom(bookList);
            return new BookListBooks {
                Book = b,
                BookId = b.BookId,
                BookList = bl,
                BookListId = bl.BookListId
            };
        });

        var bookListBooks = bookListBookFaker.Generate(10);
        
        context.Authors.AddRange(authors);
        context.Books.AddRange(books);
        context.BookAuthors.AddRange(bookAuthors);
        context.BookLists.AddRange(bookList);
        context.BookListBooks.AddRange(bookListBooks);
        context.SaveChanges();
    }
}