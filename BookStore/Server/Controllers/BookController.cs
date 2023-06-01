using BookStore.Server.Abstraction;
using BookStore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
              return Ok(await _bookRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {

            return Ok(await _bookRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _bookRepository.Add(book);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            _bookRepository.Update(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            _bookRepository.Delete(id);
            return Ok();
        }

    }
}
