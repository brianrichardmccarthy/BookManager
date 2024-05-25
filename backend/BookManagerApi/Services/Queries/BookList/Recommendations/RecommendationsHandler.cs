using Contracts;
using MediatR;

namespace Services.Queries.BookList.Recommendations;

public record RecommendationsHandler : IRequestHandler<RecommendationsRequest, IEnumerable<Book>> {
    public Task<IEnumerable<Book>> Handle(RecommendationsRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}