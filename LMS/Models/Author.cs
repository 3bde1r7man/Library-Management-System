namespace LMS.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; } = string.Empty;
        public List<Book>? Books { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
