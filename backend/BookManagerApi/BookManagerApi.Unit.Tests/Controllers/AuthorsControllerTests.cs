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
public class AuthorsControllerTests {
    private AuthorsController _controller;
    private Mock<IMediator> _mediator;
    private Mock<IValidator<Author>> _authorValidator;
    private Mock<IValidator<Guid>> _guidValidator;

    [SetUp]
    public void SetUp() {
        _mediator = new Mock<IMediator>();
        _authorValidator = new Mock<IValidator<Author>>();
        _guidValidator = new Mock<IValidator<Guid>>();
        _controller = new AuthorsController(_mediator.Object, _authorValidator.Object, _guidValidator.Object);
    }
    
    [Test]
    public void CreateAsync_CreatesAuthor() {
        Action action = () => _controller.CreateAsync(new Author());
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void GetAsync_ReturnsAuthor() {
        Action action = () => _controller.GetAsync(Guid.Empty);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void SearchAsync_ReturnsList() {
        Action action = () => _controller.SearchAsync(new SearchAuthorRequest());
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void DeleteAsync_DeletesAuthor() {
        var action = () => _controller.DeleteAsync(Guid.Empty);
        action.Should().NotThrow<NotImplementedException>();
    }
}
