using Repository.Models;

namespace Repository.Authors.Interfaces;

public interface IAuthorMutationRepository {
    Task<Guid> CreateAsync(Author author, CancellationToken cancellationToken);
    Task<Guid> UpdateAsync(Author author, CancellationToken cancellationToken);
    Task DeleteAsync(Guid authorId, CancellationToken cancellationToken);
}