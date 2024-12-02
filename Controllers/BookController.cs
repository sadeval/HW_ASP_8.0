using HW_ASP_8._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_ASP_8._0.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new BookViewModel());
        }

        [HttpPost]
        public IActionResult Add(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Genre = model.Genre,
                    Year = model.Year
                };
                _bookService.AddBook(book);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
