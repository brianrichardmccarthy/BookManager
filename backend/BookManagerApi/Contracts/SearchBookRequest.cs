namespace Contracts;

public record SearchBookRequest {
    public string Name { get; init; } = string.Empty;
    public string Isbn { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public int PageNumber { get; init; } = 1;
    public int PageCount { get; init; } = 10;
}