using MediatR;

namespace Services.Commands.Author.Delete;

public record DeleteHandler : IRequestHandler<DeleteRequest> {
    public Task Handle(DeleteRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}