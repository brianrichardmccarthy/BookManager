namespace Repository.Cache.Interfaces;

public interface ICacheRepository<T> where T : class {
    Task<T> GetAsync(string key, CancellationToken cancellationToken);
    Task SetAsync(string key, T item, CancellationToken cancellationToken);
    Task DeleteAsync(string key, CancellationToken cancellationToken);
}