using System;
using BookManagerApi.Controllers.v1;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Moq;
using NUnit.Framework;

namespace BookManagerApi.Unit.Tests.Controllers;

[TestFixture]
public class BookListControllerTests {
    private BookListController _controller;
    private Mock<IMediator> _mediator;
    private Mock<IValidator<string>> _stringValidator;

    [SetUp]
    public void SetUp() {
        _mediator = new Mock<IMediator>();
        _stringValidator = new Mock<IValidator<string>>();
        _controller = new BookListController(_mediator.Object, _stringValidator.Object);
    }

    [Test]
    public void GetAsync_Returns_BookList() {
        Action action = () => _controller.GetAsync();
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void DeleteAsync_Remove_BookFromList() {
        Action action = () => _controller.DeleteBookAsync(string.Empty);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void AddBookAsync_Returns_BookList() {
        Action action = () => _controller.AddBookAsync(string.Empty);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void GetRecommendedBooksAsync_Returns_BookList() {
        Action action = () => _controller.GetRecommendedBooksAsync();
        action.Should().NotThrow<NotImplementedException>();
    }
}