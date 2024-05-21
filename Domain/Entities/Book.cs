namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    // ?
    public List<BookCategory> BookCategories { get; set; } = [];
    public List<BookAuthor> BookAuthors { get; set; }
}