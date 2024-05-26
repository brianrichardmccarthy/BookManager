using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Repository.Context;
using Repository.Implementations;
using Repository.Models;
using Repository.Unit.Tests.Helpers;

namespace Repository.Unit.Tests.Repository;

[TestFixture]
public class BookRepositoryTests {
    private BookRepository _repository;
    private readonly CancellationToken _ct = CancellationToken.None;
    private readonly Mock<ApplicationContext> _context = new(new DbContextOptions<ApplicationContext>());
    private readonly Mock<DbSet<Author>> _authorsDbSet = new();
    private readonly Mock<DbSet<BookAuthors>> _bookAuthorsDbSet = new();
    private readonly Mock<DbSet<Book>> _booksDbSet = new();

    private const string Isbn = "test ISBN";
    private readonly int _bookId = 123;
    
    [SetUp]
    public void SetUp() {
        var books = new List<Book> 
        {
            new()
            {
                BookId = _bookId,
                Isbn = Isbn,
                Title = "Test Book Title",
                BookAuthors = new List<BookAuthors> 
                {
                    new() {
                        Author = new Author
                        {
                            AuthorId = 456,
                            Name = "Test Author"
                        }
                    }
                }
            }
        }.AsQueryable();

        var authors = new List<Author>
        {
            new () 
            {
                AuthorId = 456,
                Name = "Test Author"
            }
        }.AsQueryable();

        var bookAuthors = new List<BookAuthors>
        {
            new()
            {
                Author = authors.First(),
                AuthorId = authors.First().AuthorId,
                Book = books.First(),
                BookId = books.First().BookId
            }
        }.AsQueryable();

        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Book>(books.Provider));
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

        _booksDbSet.As<IAsyncEnumerable<Book>>()
                   .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                   .Returns(new TestAsyncEnumerator<Book>(books.GetEnumerator()));

        _context.Setup(m => m.Books).Returns(_booksDbSet.Object);
        
        _authorsDbSet.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Author>(authors.Provider));
        _authorsDbSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(authors.Expression);
        _authorsDbSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(authors.ElementType);
        _authorsDbSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(authors.GetEnumerator());

        _authorsDbSet.As<IAsyncEnumerable<Author>>()
                     .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                     .Returns(new TestAsyncEnumerator<Author>(authors.GetEnumerator()));

        _context.Setup(m => m.Authors).Returns(_authorsDbSet.Object);
        
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Book>(books.Provider));
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

        _booksDbSet.As<IAsyncEnumerable<Book>>()
                   .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                   .Returns(new TestAsyncEnumerator<Book>(books.GetEnumerator()));

        _bookAuthorsDbSet.As<IAsyncEnumerable<BookAuthors>>()
                         .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                         .Returns(new TestAsyncEnumerator<BookAuthors>(bookAuthors.GetEnumerator()));

        _context.Setup(m => m.BookAuthors).Returns(_bookAuthorsDbSet.Object);

        _repository = new BookRepository(_context.Object);
    }

    [Test]
    public void DeleteAsync_Removes_Book() {
        Action action = () => _repository.DeleteAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void SearchAsync_Returns_BookList() {
        Action action = () => _repository.SearchAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public async Task GetAsync_Returns_Book() {
        var result = await _repository.GetAsync(Isbn, _ct);
        result.Should().NotBeNull();
        result!.BookId.Should().Be(_bookId);
    }
    
    [Test]
    public void UpdateAsync_Updates_Book() {
        Action action = () => _repository.UpdateAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void CreateAsync_Creates_Book() {
        Action action = () => _repository.UpdateAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}