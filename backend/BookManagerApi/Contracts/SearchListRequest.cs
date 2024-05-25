namespace Contracts;

public class SearchListRequest {
    public string Name { get; init; } = string.Empty;
    public string Isbn { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public ReadingStatus? ReadingStatus { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageCount { get; init; } = 10;
}