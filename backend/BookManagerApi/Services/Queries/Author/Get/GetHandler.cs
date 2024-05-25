using MediatR;

namespace Services.Queries.Author.Get;

public record GetHandler : IRequestHandler<GetRequest, Contracts.Author> {
    public Task<Contracts.Author> Handle(GetRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}