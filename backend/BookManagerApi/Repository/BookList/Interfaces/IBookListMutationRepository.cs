namespace Repository.BookList.Interfaces;

public interface IBookListMutationRepository {
    Task AddAsync(string isbn, CancellationToken cancellationToken);
    Task DeleteAsync(string isbn, CancellationToken cancellationToken);
}