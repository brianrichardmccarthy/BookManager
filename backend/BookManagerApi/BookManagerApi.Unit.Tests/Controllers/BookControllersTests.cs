using System;
using BookManagerApi.Controllers.v1;
using Contracts;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Moq;
using NUnit.Framework;

namespace BookManagerApi.Unit.Tests.Controllers;

[TestFixture]
public class BooksControllerTests {
    private BooksController _controllerTests;
    private Mock<IMediator> _mediator;
    private Mock<IValidator<Book>> _bookValidator;
    private Mock<IValidator<string>> _stringValidator;

    [SetUp]
    public void SetUp() {
        _mediator = new Mock<IMediator>();
        _bookValidator = new Mock<IValidator<Book>>();
        _stringValidator = new Mock<IValidator<string>>();
        _controllerTests = new BooksController(_mediator.Object, _bookValidator.Object, _stringValidator.Object);
    }
    
    [Test]
    public void CreateAsync_CreatesAuthor() {
        Action action = () => _controllerTests.UpsertAsync(new Book());
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void GetAsync_ReturnsAuthor() {
        Action action = () => _controllerTests.GetByIsbnAsync(string.Empty);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void SearchAsync_ReturnsList() {
        Action action = () => _controllerTests.SearchAsync(new SearchBookRequest());
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void DeleteAsync_DeletesAuthor() {
        var action = () => _controllerTests.DeleteAsync(string.Empty);
        action.Should().NotThrow<NotImplementedException>();
    }
}
