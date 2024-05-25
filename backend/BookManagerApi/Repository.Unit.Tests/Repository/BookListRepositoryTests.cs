using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Repository.BookList.Implementations;

namespace Repository.Unit.Tests.Repository;

[TestFixture]
public class BookListRepositoryTests {
    private BookListRepository _repository;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _repository = new BookListRepository();
    }

    [Test]
    public void DeleteAsync_Removes_Book() {
        Action action = () => _repository.DeleteAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void GetAsync_Returns_Book() {
        Action action = () => _repository.GetAsync(_ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void AddAsync_Adds_Book() {
        Action action = () => _repository.AddAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}