using MediatR;

namespace Services.Commands.Books.Upsert;

public record UpsertHandler : IRequestHandler<UpsertRequest, Guid> {
    public Task<Guid> Handle(UpsertRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}