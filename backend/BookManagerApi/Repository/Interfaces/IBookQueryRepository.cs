using Repository.Models;

namespace Repository.Interfaces;

public interface IBookQueryRepository {
    Task<Book?> GetAsync(string isbn, CancellationToken cancellationToken);
    Task<IEnumerable<Book>> SearchAsync(string isbn, CancellationToken cancellationToken);
}