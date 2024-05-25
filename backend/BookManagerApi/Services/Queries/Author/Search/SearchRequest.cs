using MediatR;

namespace Services.Queries.Author.Search;

public record SearchRequest : IRequest<IEnumerable<Contracts.Author>> {
    public Contracts.SearchAuthorRequest Request { get; init; }
}