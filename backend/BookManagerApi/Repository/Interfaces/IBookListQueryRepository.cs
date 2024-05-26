using Repository.Models;

namespace Repository.Interfaces;

public interface IBookListQueryRepository {
    Task<BookList?> GetAsync(Guid publicId, CancellationToken cancellationToken);
}