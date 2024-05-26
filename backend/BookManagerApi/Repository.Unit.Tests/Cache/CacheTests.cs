using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Repository.Cache.Implementations;
using Repository.Models;
using StackExchange.Redis;

namespace Repository.Unit.Tests.Cache;

[TestFixture]
public class CacheTests {
    private CacheRepository<Author> _repository;
    private readonly CancellationToken _ct = CancellationToken.None;
    private Mock<IConnectionMultiplexer> _connectionMultiplexer;
    private Mock<IDatabase> _database;
    private Author _author = new() { AuthorId = 123 };
    
    [SetUp]
    public void SetUp() {
        _database = new Mock<IDatabase>();
        _connectionMultiplexer = new Mock<IConnectionMultiplexer>();
        
        _database
            .Setup(d => d.StringSetAsync(It.IsAny<RedisKey>(), It.IsAny<RedisValue>(), It.IsAny<TimeSpan>(), It.IsAny<When>()))
            .Returns(Task.FromResult(true))
            .Verifiable();

        var val = new RedisValue(JsonConvert.SerializeObject(_author));
        
        _database
            .Setup(d => d.StringGetAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
            .ReturnsAsync(val)
            .Verifiable();
        
        _database
            .Setup(d => d.KeyExistsAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
            .ReturnsAsync(true)
            .Verifiable();
        
        _database
            .Setup(d => d.KeyDeleteAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
            .ReturnsAsync(true)
            .Verifiable();

        _connectionMultiplexer
            .Setup(c => c.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
            .Returns(_database.Object)
            .Verifiable();
        
        _repository = new CacheRepository<Author>(_connectionMultiplexer.Object);
    }

    [Test]
    public async Task SetAsync_AddsItemToCache() {
        var author = new Author();
        
        bool result = await _repository.SetAsync("test", author, _ct);

        result.Should().BeTrue();
        _database.Verify(d => d.StringSetAsync(It.IsAny<RedisKey>(), It.IsAny<RedisValue>(), It.IsAny<TimeSpan>(), It.IsAny<When>()));
        _database.VerifyNoOtherCalls();
        _connectionMultiplexer.Verify(c => c.GetDatabase(It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        _connectionMultiplexer.VerifyNoOtherCalls();
    }
    
    [Test]
    public async Task DeleteAsync_AddsItemToCache() {
        bool result = await _repository.DeleteAsync("test", _ct);
        
        result.Should().BeTrue();
        _database.Verify(d => d.KeyExistsAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()), Times.Once);
        _database.Verify(d => d.KeyDeleteAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()), Times.Once);
        _database.VerifyNoOtherCalls();
        _connectionMultiplexer.Verify(c => c.GetDatabase(It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        _connectionMultiplexer.VerifyNoOtherCalls();
    }
    
    [Test]
    public async Task GetAsync_AddsItemToCache() {
        var result = await _repository.GetAsync("test", _ct);

        result.Should().NotBeNull();
        result!.AuthorId.Should().Be(_author.AuthorId);
        _database.Verify(d => d.StringGetAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()), Times.Once);
        _database.VerifyNoOtherCalls();
        _connectionMultiplexer.Verify(c => c.GetDatabase(It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        _connectionMultiplexer.VerifyNoOtherCalls();
    }
}