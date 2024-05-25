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
public class AuthorsControllerTests {
    private AuthorsController _controller;
    private IServiceProvider _serviceProvider;
    private IMediator _mediator;
    private IValidator<Author> _authorValidator;
    private IValidator<Guid> _guidValidator;

    [SetUp]
    public void SetUp() {
        var helper = new TestHelper();
        _serviceProvider = helper.ServiceProvider;
        _mediator = _serviceProvider.GetRequiredService<IMediator>();
        _authorValidator = _serviceProvider.GetRequiredService<IValidator<Author>>();
        _guidValidator = _serviceProvider.GetRequiredService<IValidator<Guid>>();
        _controller = new AuthorsController(_mediator, _authorValidator, _guidValidator);
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
