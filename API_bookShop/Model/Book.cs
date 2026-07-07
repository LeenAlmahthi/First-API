public class Book
{
    public Book() { }
    public Book(string title, string author, int year)
    {
        this.Title = title;
        this.Author = author;
        this.PublishedYear = year;
    }
    public int ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishedYear { get; set; }
    public int CategoryId { get; set; }
}