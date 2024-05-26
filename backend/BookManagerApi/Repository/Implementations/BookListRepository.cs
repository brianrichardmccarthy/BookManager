using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implementations;

public class BookListRepository(ApplicationContext context) : IBookListRepository {
    private readonly ApplicationContext _context = context ?? throw new ArgumentNullException(nameof(context));
    
    public async Task<BookList?> GetAsync(Guid publicId, CancellationToken cancellationToken) {
        return await _context.BookLists
                             .Include(bl => bl.BookListBooks)
                             .ThenInclude(blb => blb.Book)
                             .ThenInclude(b => b.BookAuthors)
                             .ThenInclude(ba => ba.Author)
                             .Where(bl => bl.PublicId == publicId)
                             .SingleOrDefaultAsync(cancellationToken);
    }

    public Task AddAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string isbn, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}