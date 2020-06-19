using System.Collections.Generic;
using BookShelf.Models;
using BookShelf.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookShelfController : ControllerBase
    {
        private readonly BookShelfService _bshelf;

        public BookShelfController(BookShelfService bookShelfService)
        {
            _bshelf = bookShelfService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookShelfm>> GetBookShelf() =>
         Ok(_bshelf.Get());

        [HttpGet("{id:length(24)}", Name = "GetBookShelf")]
        public ActionResult<BookShelfm> GetBookShelf(string id)
        {
            var bshelf = _bshelf.Get(id);

            if (bshelf == null)
            {
                return NotFound();
            }

            return Ok(bshelf);
        }

        [HttpPost]
        public ActionResult<BookShelfm> Create(BookShelfm bshelf)
        {

            _bshelf.Create(bshelf);

            return CreatedAtRoute(nameof(GetBookShelf), new { ID = bshelf.ID.ToString() }, bshelf);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, BookShelfm bshelfIn)
        {
            var bshelf = _bshelf.Get(id);

            if (bshelf == null)
            {
                return NotFound();
            }

            _bshelf.Update(id, bshelfIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var bshelf = _bshelf.Get(id);

            if (bshelf == null)
            {
                return NotFound();
            }

            _bshelf.Remove(bshelf.ID);

            return NoContent();
        }
    }
}