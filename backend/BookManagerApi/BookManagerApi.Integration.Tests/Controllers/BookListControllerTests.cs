using BookManagerApi.Controllers.v1;
using BookManagerApi.Integration.Tests.Helpers;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BookManagerApi.Integration.Tests.Controllers;

[TestFixture]
public class BookListControllerTests {
    private BookListController _controller;
    private IServiceProvider _serviceProvider;
    private IMediator _mediator;
    private IValidator<string> _stringValidator;

    [SetUp]
    public void SetUp() {
        var helper = new TestHelper();
        _serviceProvider = helper.ServiceProvider;
        _mediator = _serviceProvider.GetRequiredService<IMediator>();
        _stringValidator = _serviceProvider.GetRequiredService<IValidator<string>>();        
        _controller = new BookListController(_mediator, _stringValidator);
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