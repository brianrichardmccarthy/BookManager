using Repository.Cache.Interfaces;

namespace Repository.Cache.Implementations;

public class CacheRepository<T> : ICacheRepository<T> where T : class {
    public Task<T> GetAsync(string key, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task SetAsync(string key, T item, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string key, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}