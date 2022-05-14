using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semana07UESAN.DOMAIN.Core.Interfaces;

namespace Semana07UESAN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        {
            var customers = await _customerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById([FromQuery] int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            return Ok(customer);
        }


    }
}
