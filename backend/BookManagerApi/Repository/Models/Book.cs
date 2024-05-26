namespace Repository.Models;

public class Book {
    public int BookId { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public int ReadingStatus { get; set; }
    public ICollection<BookAuthors> BookAuthors { get; set; }
    public ICollection<BookListBooks> BookListBooks { get; set; }
}