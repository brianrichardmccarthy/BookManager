using Contracts;
using MediatR;

namespace Services.Queries.Books.Search;

public record SearchRequest : IRequest<IEnumerable<Book>> {
    public SearchBookRequest Request { get; init; }
}