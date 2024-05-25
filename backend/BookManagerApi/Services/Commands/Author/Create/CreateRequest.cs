using MediatR;

namespace Services.Commands.Author.Create;

public record CreateRequest : IRequest<Guid> {
    public Contracts.Author Author { get; init; }
}