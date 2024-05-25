using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Services.Commands.Author.Create;

namespace Services.Unit.Tests.Commands.Author.Create;

[TestFixture]
public class CreateHandlerTests {
    private CreateHandler _handler;
    private CreateRequest _request;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _request = new CreateRequest();
        _handler = new CreateHandler();
    }
    
    [Test]
    public void Handle_Returns_BookLists() {
        Action action = () => _handler.Handle(_request, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}