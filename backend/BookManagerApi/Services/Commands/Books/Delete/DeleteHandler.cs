using MediatR;

namespace Services.Commands.Books.Delete;

public record DeleteHandler : IRequestHandler<DeleteRequest> {
    public Task Handle(DeleteRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}