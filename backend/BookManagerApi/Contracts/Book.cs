namespace Contracts;

public record Book {
    public string Name { get; init; }
    public string Isbn { get; init; }
    public string Author { get; init; }
    public string Genre { get; init; }
    public float? Rating { get; init; } 
    public ReadingStatus ReadingStatus { get; init; }
}