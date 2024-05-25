using Repository.BookList.Interfaces;
using Repository.Models;

namespace Repository.BookList.Implementations;

public class BookListRepository : IBookListRepository {
    public Task<IEnumerable<Book>> GetAsync(CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task AddAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}