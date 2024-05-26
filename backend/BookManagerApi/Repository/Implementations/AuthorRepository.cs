using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implementations;

public class AuthorRepository(ApplicationContext context) : IAuthorRepository {
    private readonly ApplicationContext _context = context ?? throw new ArgumentNullException(nameof(context));
    public Task<Guid> CreateAsync(Author author, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task<Guid> UpdateAsync(Author author, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid authorId, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public async Task<Author?> GetAsync(Guid authorId, CancellationToken cancellationToken) {
        return await _context.Authors
                             .Include(a => a.BookAuthors)
                             .ThenInclude(ba => ba.Book)
                             .Where(a => a.PublicId == authorId)
                             .SingleOrDefaultAsync(cancellationToken);
    }

    public Task<IEnumerable<Author>> SearchAsync(CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}