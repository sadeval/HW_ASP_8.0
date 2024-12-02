using HW_ASP_8._0.Models;

namespace HW_ASP_8._0
{
    public class BookService
    {
        private readonly List<Book> _books = new();

        public IEnumerable<Book> GetBooks() => _books;

        public void AddBook(Book book)
        {
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }
    }
}
