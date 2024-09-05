using LMS.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Views.Books
{
	public class Index : PageModel
	{
		public Book? Book { get; set; }
		public Author? Author { get; set; }
	}
}
