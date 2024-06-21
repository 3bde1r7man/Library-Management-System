using System.Drawing;

namespace LMS.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AuthorId { get; set; }
        public Author? Author { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        public int? Pages { get; set; }
        public int? Year { get; set; }
    }
}
