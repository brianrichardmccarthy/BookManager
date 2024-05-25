using Contracts;
using MediatR;

namespace Services.Queries.BookList.Get;

public record GetHandler : IRequestHandler<GetRequest, IEnumerable<Book>> {
    public Task<IEnumerable<Book>> Handle(GetRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}