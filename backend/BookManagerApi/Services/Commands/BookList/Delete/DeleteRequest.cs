using MediatR;

namespace Services.Commands.BookList.Delete;

public record DeleteRequest : IRequest {
    public string Isbn { get; init; }
}