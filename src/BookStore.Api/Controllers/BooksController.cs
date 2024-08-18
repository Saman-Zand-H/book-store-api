using BookStore.Api.Models;
using BookStore.Api.Services;
using BookStore.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _booksService = bookService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadDto>>> Get() => Ok(await _booksService.GetBooksAsync());

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<BookReadDto?>> Get([FromRoute] string id)
        {
            var book = await _booksService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] BookCreateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            BookReadDto book = await _booksService.AddBookAsync(bookDto);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] BookUpdateDto bookDto)
        {
            var book = await _booksService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _booksService.UpdateBookAsync(id, bookDto);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var book = await _booksService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _booksService.DeleteBookAsync(id);
            return Ok();
        }
    }
}
