namespace LibraryApi.Models;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public string Author { get; set; } = string.Empty;
    
    public int YearOfPublication { get; set; }
    public ReadingStatus ReadingStatus { get; set; } = ReadingStatus.NotStarted;

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}