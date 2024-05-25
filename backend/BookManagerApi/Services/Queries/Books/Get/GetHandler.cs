using Contracts;
using MediatR;

namespace Services.Queries.Books.Get;

public record GetHandler : IRequestHandler<GetRequest, Book> {
    public Task<Book> Handle(GetRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}