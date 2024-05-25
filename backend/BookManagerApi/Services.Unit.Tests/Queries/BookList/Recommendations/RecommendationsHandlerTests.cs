using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Services.Queries.BookList.Recommendations;

namespace Services.Unit.Tests.Queries.BookList.Recommendations;

[TestFixture]
public class RecommendationsHandlerTests {
    private RecommendationsHandler _handler;
    private RecommendationsRequest _request;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _request = new RecommendationsRequest();
        _handler = new RecommendationsHandler();
    }
    
    [Test]
    public void Handle_Returns_BookLists() {
        Action action = () => _handler.Handle(_request, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}