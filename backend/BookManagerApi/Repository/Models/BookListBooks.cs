namespace Repository.Models;

public class BookListBooks {
    public int BookListId { get; set; }
    public BookList BookList { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
}