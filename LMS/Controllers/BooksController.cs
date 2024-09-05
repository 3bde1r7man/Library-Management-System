using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.Data;
using LMS.Models;
using LMS.Views.Books;
using Index = LMS.Views.Books.Index;

namespace LMS.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            Index details = new Index();
            List<Index> IndexList = new List<Index>();

            var books = await _context.Books
                .Include(b => b.Category)
                .ToListAsync();

            foreach (var book in books)
                {
                details.Book = book;
                details.Author = await _context.Authors
                    .FirstOrDefaultAsync(m => m.Id == book.AuthorId);
                IndexList.Add(details);
            }

            return View(IndexList);
        }

		// GET: Books/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			Details details = new Details();
			if (id == null)
			{
				return NotFound();
			}

			details.Book = await _context.Books
				.Include(b => b.Category)
				.FirstOrDefaultAsync(m => m.Id == id);

			if (details.Book == null)
			{
				return NotFound();
			}

			details.Author = await _context.Authors
				.FirstOrDefaultAsync(m => m.Id == details.Book.AuthorId);
			if (details.Author == null)
			{
				return NotFound();
			}

			return View(details);

		}

		// GET: Books/Create
		public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "FullName");
            return View();
        }


        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,AuthorId,CategoryId,Description,ISBN,Pages,Year")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", book.CategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", book.CategoryId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,AuthorId,CategoryId,Description,ISBN,Pages,Year")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", book.CategoryId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
