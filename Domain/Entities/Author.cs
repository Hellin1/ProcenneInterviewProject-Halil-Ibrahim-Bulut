namespace Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
}
