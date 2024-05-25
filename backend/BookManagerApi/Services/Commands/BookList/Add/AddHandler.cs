using MediatR;

namespace Services.Commands.BookList.Add;

public record AddHandler : IRequestHandler<AddRequest> {
    public Task Handle(AddRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}