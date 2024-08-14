using BookStore.Api.DTOs;
using BookStore.Api.Models;
using BookStore.Api.Repositories;
using Mapster;

namespace BookStore.Api.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookReadDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            return books.Adapt<IEnumerable<BookReadDto>>();
        }

        public async Task<BookReadDto?> GetBookAsync(string id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            return book?.Adapt<BookReadDto>();
        }

        public async Task<BookReadDto> AddBookAsync(BookCreateDto createBookCreateDto)
        {
            var book = createBookCreateDto.Adapt<Book>();
            await _bookRepository.AddBookAsync(book);
            return book.Adapt<BookReadDto>();
        }

        public async Task UpdateBookAsync(string id, BookUpdateDto bookDto)
        {
            var book = bookDto.Adapt<Book>();
            book.Id = id;
            await _bookRepository.UpdateBookAsync(id, book);
        }

        public async Task DeleteBookAsync(string id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}
