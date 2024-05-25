using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Services.Queries.Books.Search;

namespace Services.Unit.Tests.Queries.Books.Search;

[TestFixture]
public class SearchHandlerTests {
    private SearchHandler _handler;
    private SearchRequest _request;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _request = new SearchRequest();
        _handler = new SearchHandler();
    }
    
    [Test]
    public void Handle_Returns_BookLists() {
        Action action = () => _handler.Handle(_request, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}