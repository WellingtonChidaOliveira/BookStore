using BookStore.Server.UseCases.RentalBookCases;
using BookStore.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalBookController : Controller
    {
        private readonly IRentalBookRepository _rentalBookRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalBookController(IRentalBookRepository rentalBookRepository, ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _rentalBookRepository = rentalBookRepository;
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rentalBooks = await _rentalBookRepository.GetAll();
            return Ok(rentalBooks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var rentalBook = await _rentalBookRepository.Get(id);
            return Ok(rentalBook);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RentalBook rentalBook)
        {
            await _rentalBookRepository.Add(rentalBook);
            return Ok(rentalBook);
        }
        [HttpPut]
        public async Task<IActionResult> Put(RentalBook rentalBook)
        {
            await _rentalBookRepository.Update(rentalBook);
            return Ok(rentalBook);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _rentalBookRepository.Delete(id);
            return Ok();
        }
    }
}
