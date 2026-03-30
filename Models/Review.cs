namespace LibraryApi.Models;
public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string UserName { get; set; } = string.Empty;
    
    public int Rating { get; set; }
    
    public string Comment { get; set; } = string.Empty;

    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;

}