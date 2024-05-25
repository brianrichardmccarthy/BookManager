using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Repository.Authors.Implementations;
using Repository.Models;

namespace Repository.Unit.Tests.Repository;

[TestFixture]
public class AuthorRepositoryTests {
    private AuthorRepository _repository;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _repository = new AuthorRepository();
    }

    [Test]
    public void DeleteAsync_Removes_Book() {
        Action action = () => _repository.DeleteAsync(Guid.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void SearchAsync_Returns_BookList() {
        Action action = () => _repository.SearchAsync(_ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void GetAsync_Returns_Book() {
        Action action = () => _repository.GetAsync(Guid.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void UpdateAsync_Updates_Book() {
        Action action = () => _repository.UpdateAsync(new Author(), _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void CreateAsync_Creates_Book() {
        Action action = () => _repository.UpdateAsync(new Author(), _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}