using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Services.Commands.Books.Upsert;

namespace Services.Unit.Tests.Commands.Books.Upsert;

[TestFixture]
public class UpsertHandlerTests {
    private UpsertHandler _handler;
    private UpsertRequest _request;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _request = new UpsertRequest();
        _handler = new UpsertHandler();
    }
    
    [Test]
    public void Handle_Returns_BookLists() {
        Action action = () => _handler.Handle(_request, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}