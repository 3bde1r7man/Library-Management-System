using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;

namespace LMS.Views.Books
{
	public class Details : PageModel
	{
		public Book? Book { get; set; }
		public Author? Author { get; set; }
	}
}
