using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Services.Commands.BookList.Delete;

namespace Services.Unit.Tests.Commands.BookList.Delete;

[TestFixture]
public record DeleteHandlerTests {
    private DeleteHandler _handler;
    private DeleteRequest _request;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _request = new DeleteRequest();
        _handler = new DeleteHandler();
    }
    
    [Test]
    public void Handle_Returns_BookLists() {
        Action action = () => _handler.Handle(_request, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}