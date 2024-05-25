using MediatR;

namespace Services.Commands.BookList.Add;

public record AddRequest : IRequest {
    public string Isbn { get; init; }
}