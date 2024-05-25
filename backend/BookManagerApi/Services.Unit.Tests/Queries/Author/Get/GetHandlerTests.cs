using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Services.Queries.Author.Get;

namespace Services.Unit.Tests.Queries.Author.Get;

[TestFixture]
public class GetHandlerTests {
    private GetHandler _handler;
    private GetRequest _request;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _request = new GetRequest();
        _handler = new GetHandler();
    }
    
    [Test]
    public void Handle_Returns_BookLists() {
        Action action = () => _handler.Handle(_request, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}