using System.Collections.Generic;
using BookShelf.Models;
using BookShelf.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBook() =>
           Ok(_bookService.Get());

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Book> GetBook(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {

            _bookService.Create(book);

            return CreatedAtRoute(nameof(GetBook), new { ID = book.ID.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.ID);

            return NoContent();
        }
    }
}