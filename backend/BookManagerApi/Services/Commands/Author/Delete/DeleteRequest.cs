using MediatR;

namespace Services.Commands.Author.Delete;

public record DeleteRequest : IRequest {
    public Guid AuthorId { get; init; }
}