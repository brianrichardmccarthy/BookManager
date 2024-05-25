using Repository.Models;

namespace Repository.BookList.Interfaces;

public interface IBookListQueryRepository {
    Task<IEnumerable<Book>> GetAsync(CancellationToken cancellationToken);
}