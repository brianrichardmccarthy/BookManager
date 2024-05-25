using MediatR;

namespace Services.Queries.Author.Search;

public record SearchHandler : IRequestHandler<SearchRequest, IEnumerable<Contracts.Author>> {
    public Task<IEnumerable<Contracts.Author>> Handle(SearchRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}