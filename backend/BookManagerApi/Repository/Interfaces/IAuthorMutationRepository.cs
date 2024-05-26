using Repository.Models;

namespace Repository.Interfaces;

public interface IAuthorMutationRepository {
    Task<Guid> CreateAsync(Author author, CancellationToken cancellationToken);
    Task<Guid> UpdateAsync(Author author, CancellationToken cancellationToken);
    Task DeleteAsync(Guid authorId, CancellationToken cancellationToken);
}