using Contracts;
using MediatR;

namespace Services.Queries.Books.Search;

public record SearchHandler : IRequestHandler<SearchRequest, IEnumerable<Book>> {
    public Task<IEnumerable<Book>> Handle(SearchRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}