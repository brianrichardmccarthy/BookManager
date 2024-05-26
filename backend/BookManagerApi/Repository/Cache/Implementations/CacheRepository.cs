using Newtonsoft.Json;
using Repository.Cache.Interfaces;
using StackExchange.Redis;

namespace Repository.Cache.Implementations;

public class CacheRepository<T> (IConnectionMultiplexer connectionMultiplexer) : ICacheRepository<T> where T : class {
    private readonly IConnectionMultiplexer _redis = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
    
    public async Task<T?> GetAsync(string key, CancellationToken cancellationToken) {
        var db = _redis.GetDatabase();
        var value = await db.StringGetAsync(key);
        return !value.HasValue ? null : JsonConvert.DeserializeObject<T>(value!);
    }

    public async Task<bool> SetAsync(string key, T item, CancellationToken cancellationToken) {
        var db = _redis.GetDatabase();
        string json = JsonConvert.SerializeObject(item);
        return await db.StringSetAsync(key, json, TimeSpan.FromMinutes(5), When.NotExists);
    }

    public async Task<bool> DeleteAsync(string key, CancellationToken cancellationToken) {
        var db = _redis.GetDatabase();
        if (!await db.KeyExistsAsync(key)) {
            return false;
        }
        return await db.KeyDeleteAsync(key);
    }
}