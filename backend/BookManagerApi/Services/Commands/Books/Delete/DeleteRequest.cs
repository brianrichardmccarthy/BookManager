using MediatR;

namespace Services.Commands.Books.Delete;

public record DeleteRequest : IRequest {
    public string Isbn { get; init; }
}