using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Services.Commands.Author.Delete;

namespace Services.Unit.Tests.Commands.Author.Delete;

[TestFixture]
public class DeleteHandlerTests {
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