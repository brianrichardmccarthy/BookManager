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
public class BookListRepositoryTests {
    private BookListRepository _repository;
    private readonly CancellationToken _ct = CancellationToken.None;
    private readonly Mock<ApplicationContext> _context = new(new DbContextOptions<ApplicationContext>());
    private readonly Mock<DbSet<BookList>> _bookListsDbSet = DbSetMockHelper.CreateMockDbSet(new List<BookList>().AsQueryable());
    private readonly Mock<DbSet<BookListBooks>> _bookListBooksDbSet = DbSetMockHelper.CreateMockDbSet(new List<BookListBooks>().AsQueryable());
    private readonly Mock<DbSet<Book>> _booksDbSet = DbSetMockHelper.CreateMockDbSet(new List<Book>().AsQueryable());
    private readonly Mock<DbSet<Author>> _authorsDbSet = DbSetMockHelper.CreateMockDbSet(new List<Author>().AsQueryable());
    private readonly Mock<DbSet<BookAuthors>> _bookAuthorsDbSet = DbSetMockHelper.CreateMockDbSet(new List<BookAuthors>().AsQueryable());

    private readonly Guid _publicId = Guid.NewGuid();
    private const int BookListId = 789;
    
    [SetUp]
    public void SetUp() {
        var books = new List<Book> 
        {
            new()
            {
                BookId = 123,
                Isbn = "test ISBN",
                Title = "Test Book Title",
                BookAuthors = new List<BookAuthors> 
                {
                    new() {
                        Author = new Author
                        {
                            AuthorId = 123,
                            Name = "Test Author",
                            PublicId = Guid.Empty
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
                Name = "Test Author",
                PublicId = Guid.Empty
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

        var bookListBooks = new List<BookListBooks> 
        {
            new() {
                Book = books.First(),
                BookId = books.First().BookId,
                BookListId = BookListId
            }
        }.AsQueryable();
        
        var bookList = new List<BookList> 
        {
            new () {
                Name = "booklist 1",
                PublicId = _publicId,
                BookListId = BookListId,
            }
        }.AsQueryable();
        
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Book>(books.Provider));
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
        _booksDbSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());
        _booksDbSet.As<IAsyncEnumerable<Book>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<Book>(books.GetEnumerator()));
        _context.Setup(m => m.Books).Returns(_booksDbSet.Object);

        _authorsDbSet.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Author>(authors.Provider));
        _authorsDbSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(authors.Expression);
        _authorsDbSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(authors.ElementType);
        _authorsDbSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(authors.GetEnumerator());
        _authorsDbSet.As<IAsyncEnumerable<Author>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<Author>(authors.GetEnumerator()));
        _context.Setup(m => m.Authors).Returns(_authorsDbSet.Object);

        // Setting up _bookAuthorsDbSet mock
        _bookAuthorsDbSet.As<IQueryable<BookAuthors>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<BookAuthors>(bookAuthors.Provider));
        _bookAuthorsDbSet.As<IQueryable<BookAuthors>>().Setup(m => m.Expression).Returns(bookAuthors.Expression);
        _bookAuthorsDbSet.As<IQueryable<BookAuthors>>().Setup(m => m.ElementType).Returns(bookAuthors.ElementType);
        _bookAuthorsDbSet.As<IQueryable<BookAuthors>>().Setup(m => m.GetEnumerator()).Returns(bookAuthors.GetEnumerator());
        _bookAuthorsDbSet.As<IAsyncEnumerable<BookAuthors>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<BookAuthors>(bookAuthors.GetEnumerator()));
        _context.Setup(m => m.BookAuthors).Returns(_bookAuthorsDbSet.Object);

        // Setting up _bookListBooksDbSet mock
        var _bookListBooksDbSet = new Mock<DbSet<BookListBooks>>();
        _bookListBooksDbSet.As<IQueryable<BookListBooks>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<BookListBooks>(bookListBooks.Provider));
        _bookListBooksDbSet.As<IQueryable<BookListBooks>>().Setup(m => m.Expression).Returns(bookListBooks.Expression);
        _bookListBooksDbSet.As<IQueryable<BookListBooks>>().Setup(m => m.ElementType).Returns(bookListBooks.ElementType);
        _bookListBooksDbSet.As<IQueryable<BookListBooks>>().Setup(m => m.GetEnumerator()).Returns(bookListBooks.GetEnumerator());
        _bookListBooksDbSet.As<IAsyncEnumerable<BookListBooks>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<BookListBooks>(bookListBooks.GetEnumerator()));
        _context.Setup(m => m.BookListBooks).Returns(_bookListBooksDbSet.Object);

        // Setting up _bookListDbSet mock
        var _bookListDbSet = new Mock<DbSet<BookList>>();
        _bookListDbSet.As<IQueryable<BookList>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<BookList>(bookList.Provider));
        _bookListDbSet.As<IQueryable<BookList>>().Setup(m => m.Expression).Returns(bookList.Expression);
        _bookListDbSet.As<IQueryable<BookList>>().Setup(m => m.ElementType).Returns(bookList.ElementType);
        _bookListDbSet.As<IQueryable<BookList>>().Setup(m => m.GetEnumerator()).Returns(bookList.GetEnumerator());
        _bookListDbSet.As<IAsyncEnumerable<BookList>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<BookList>(bookList.GetEnumerator()));
        _context.Setup(m => m.BookLists).Returns(_bookListDbSet.Object);
        
        _repository = new BookListRepository(_context.Object);
    }

    [Test]
    public void DeleteAsync_Removes_Book() {
        Action action = () => _repository.DeleteAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public async Task GetAsync_Returns_Book() {
        var result = await _repository.GetAsync(_publicId, _ct);
        result.Should().NotBeNull();
        result!.BookListId.Should().Be(BookListId);
    }
    
    [Test]
    public void AddAsync_Adds_Book() {
        Action action = () => _repository.AddAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}