using Repository.Books.Interfaces;
using Repository.Models;

namespace Repository.Books.Implementations;

public class BookRepository : IBookRepository {
    public Task DeleteAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task CreateAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
    
    public Task UpdateAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task<Book> GetAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> SearchAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}