using Contracts;
using MediatR;

namespace Services.Queries.Books.Get;

public record GetRequest : IRequest<Book> {
    public string Isbn { get; init; }
}