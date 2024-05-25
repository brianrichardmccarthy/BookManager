using MediatR;

namespace Services.Commands.Author.Create;

public record CreateHandler : IRequestHandler<CreateRequest, Guid> {
    public Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}