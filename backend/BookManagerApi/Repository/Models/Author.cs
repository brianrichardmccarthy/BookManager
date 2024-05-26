namespace Repository.Models;

public class Author {
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public Guid PublicId { get; set; }
    public ICollection<BookAuthors> BookAuthors { get; set; }
}