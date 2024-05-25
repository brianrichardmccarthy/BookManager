using BookManagerApi.Controllers.v1;
using BookManagerApi.Integration.Tests.Helpers;
using Contracts;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BookManagerApi.Integration.Tests.Controllers;

[TestFixture]
public class BooksControllerTests {
    private BooksController _controllerTests;
    private IServiceProvider _serviceProvider;
    private IMediator _mediator;
    private IValidator<Book> _bookValidator;
    private IValidator<string> _stringValidator;

    [SetUp]
    public void SetUp() {
        var helper = new TestHelper();
        _serviceProvider = helper.ServiceProvider;
        _mediator = _serviceProvider.GetRequiredService<IMediator>();
        _bookValidator = _serviceProvider.GetRequiredService<IValidator<Book>>();
        _stringValidator = _serviceProvider.GetRequiredService<IValidator<string>>();
        _controllerTests = new BooksController(_mediator, _bookValidator, _stringValidator);
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
