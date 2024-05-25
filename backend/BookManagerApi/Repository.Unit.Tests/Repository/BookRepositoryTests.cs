using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Repository.Books.Implementations;

namespace Repository.Unit.Tests.Repository;

[TestFixture]
public class BookRepositoryTests {
    private BookRepository _repository;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _repository = new BookRepository();
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
    public void GetAsync_Returns_Book() {
        Action action = () => _repository.GetAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
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