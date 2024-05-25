using Contracts;
using MediatR;

namespace Services.Queries.BookList.Recommendations;

public record RecommendationsRequest : IRequest<IEnumerable<Book>> { }