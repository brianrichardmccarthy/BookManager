using Repository.Models;

namespace Repository.Interfaces;

public interface IAuthorQueryRepository {
    Task<Author?> GetAsync(Guid authorId, CancellationToken cancellationToken);
    Task<IEnumerable<Author>> SearchAsync(CancellationToken cancellationToken);
}