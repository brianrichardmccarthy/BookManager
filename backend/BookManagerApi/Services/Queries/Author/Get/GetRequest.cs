using MediatR;

namespace Services.Queries.Author.Get;

public record GetRequest : IRequest<Contracts.Author> {
    public Guid AuthorId { get; init; }
}