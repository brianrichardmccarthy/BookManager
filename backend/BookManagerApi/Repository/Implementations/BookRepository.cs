using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implementations;

public class BookRepository(ApplicationContext context) : IBookRepository {
    private readonly ApplicationContext _context = context ?? throw new ArgumentNullException(nameof(context));
    public Task DeleteAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task CreateAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
    
    public Task UpdateAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public async Task<Book?> GetAsync(string isbn, CancellationToken cancellationToken) {
        return await _context.Books
                             .Include(a => a.BookAuthors)
                             .ThenInclude(ba => ba.Author)
                             .Where(b => isbn == b.Isbn)
                             .SingleOrDefaultAsync(cancellationToken);
    }

    public Task<IEnumerable<Book>> SearchAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}