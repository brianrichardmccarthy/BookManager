using Contracts;
using MediatR;

namespace Services.Queries.BookList.Get;

public record GetRequest : IRequest<IEnumerable<Book>> { }