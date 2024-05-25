using Repository.Authors.Interfaces;
using Repository.Models;

namespace Repository.Authors.Implementations;

public class AuthorRepository : IAuthorRepository {
    public Task<Guid> CreateAsync(Author author, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task<Guid> UpdateAsync(Author author, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid authorId, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task<Author> GetAsync(Guid authorId, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Author>> SearchAsync(CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}