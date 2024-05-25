using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Services.Commands.BookList.Add;

namespace Services.Unit.Tests.Commands.BookList.Add;

[TestFixture]
public class AddHandlerTests {
    private AddHandler _handler;
    private AddRequest _request;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _request = new AddRequest();
        _handler = new AddHandler();
    }
    
    [Test]
    public void Handle_Returns_BookLists() {
        Action action = () => _handler.Handle(_request, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}