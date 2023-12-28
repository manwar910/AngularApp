using CustomerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            try
            {
                return Ok(await customerRepository.GetCustomers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            try
            {
                var result = await customerRepository.GetCustomer(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");

            }
        }

        [HttpPost()]
        public async Task<ActionResult<HttpResponseMessage>> PostCustomer(Customer customer)
        {
            try
            {
                Customer data = new Customer();
                if (customer == null)
                {
                    return BadRequest();
                }
                
                if (customer.customerId == 0)
                {
                    var emp = await customerRepository.GetCustomerByEmail(customer.email);
                    if (emp != null)
                    {
                        ModelState.AddModelError("email", "Customer email already in use");
                        return BadRequest();
                    }
                    customer.createdDate=DateTime.Now;
                    customer.lastUpdatedDate = DateTime.Now;
                    data = await customerRepository.AddCustomer(customer);
                }
                else
                {
                    data = await customerRepository.UpdateCustomer(customer);
                }

                return CreatedAtAction(nameof(GetCustomer), new { id = data.customerId }, data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = await customerRepository.GetCustomer(id);
                if (customerToDelete == null)
                {
                    return NotFound($"Customer with Id = {id} not found");
                }
                return await customerRepository.DeleteCustomer(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }
    }
}
