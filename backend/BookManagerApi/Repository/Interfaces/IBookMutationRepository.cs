namespace Repository.Interfaces;

public interface IBookMutationRepository {
    Task DeleteAsync(string isbn, CancellationToken cancellationToken);
    Task UpdateAsync(string isbn, CancellationToken cancellationToken);
    Task CreateAsync(string isbn, CancellationToken cancellationToken);
}