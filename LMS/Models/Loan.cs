namespace LMS.Models
{
	public class Loan
	{
		public int Id { get; set; }
		public int? BookId { get; set; }
		public Book? Book { get; set; }
		public string? UserId { get; set; }
		public User? User { get; set; }
		public DateTime? BorrowDate { get; set; }
		public DateTime? ReturnDate { get; set; }
		public bool? Returned { get; set; }
	}
}
