using System.Collections.Generic;

namespace Contracts;

public class Author {
    public string Name { get; init; }
    public string Description { get; init; }
    public IEnumerable<string> BookNames { get; init; }
}