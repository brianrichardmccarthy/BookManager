using MediatR;

namespace Services.Commands.Books.Upsert;

public record UpsertRequest : IRequest<Guid> {
    public Contracts.Book Book { get; init; }
}