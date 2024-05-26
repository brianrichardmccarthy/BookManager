namespace Repository.Models;

public class BookList {
    public int BookListId { get; set; }
    public string Name { get; set; }
    public Guid PublicId { get; set; }
    public ICollection<BookListBooks> BookListBooks { get; set; }
}