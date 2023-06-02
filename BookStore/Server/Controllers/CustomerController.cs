using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        //TODO: Apply rules for password and towards to end see something about authentication
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return Ok(await _customerRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> Get(string id)
        {
            var customer = await _customerRepository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            await _customerRepository.Add(customer);
            return Ok(customer);
        }
        [HttpPut]
        public async Task<ActionResult<Customer>> Put(Customer customer)
        {
            await _customerRepository.Update(customer);
            return Ok(customer);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> Delete(string id)
        {
            await _customerRepository.Delete(id);
            return Ok();
        }
    }
}
