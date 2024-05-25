using System;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using Repository.Cache.Implementations;
using Repository.Models;

namespace Repository.Unit.Tests.Cache;

[TestFixture]
public class CacheTests {
    private CacheRepository<Author> _cacheRepository;
    private readonly CancellationToken _ct = CancellationToken.None;

    [SetUp]
    public void SetUp() {
        _cacheRepository = new CacheRepository<Author>();
    }

    [Test]
    public void SetAsync_AddsItemToCache() {
        Action action = () => _cacheRepository.SetAsync(string.Empty, new Author(), _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void DeleteAsync_AddsItemToCache() {
        Action action = () => _cacheRepository.DeleteAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
    
    [Test]
    public void GetAsync_AddsItemToCache() {
        Action action = () => _cacheRepository.GetAsync(string.Empty, _ct);
        action.Should().NotThrow<NotImplementedException>();
    }
}