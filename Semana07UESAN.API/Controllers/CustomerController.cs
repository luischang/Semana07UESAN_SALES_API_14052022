using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semana07UESAN.DOMAIN.Core.DTOs;
using Semana07UESAN.DOMAIN.Core.Entities;
using Semana07UESAN.DOMAIN.Core.Interfaces;

namespace Semana07UESAN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }       

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        {
            var customers = await _customerRepository.GetCustomers();
            //Convert customers to CustomertDTO
            //var customersList = new List<CustomerDTO>();
            //foreach (var item in customers) {
            //    var customerDTO = new CustomerDTO()
            //    {
            //        Id = item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        City = item.City,
            //        Country = item.Country,
            //        Phone = item.Phone
            //    };
            //    customersList.Add(customerDTO);
            //}            
            var customersList = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customersList);
        }

        [HttpGet("GetAllSP")]
        public IActionResult GetAllSP()
        {
            var customers = _customerRepository.GetCustomersSP();
            return Ok(customers);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if(customer == null)
                return NotFound();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById([FromQuery] int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customer);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CustomerPostDTO customerDTO)
        {           
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Insert(customer);
            return Ok(customer.Id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO.Id == 0)
                return NotFound();
        
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.Update(customer);
            if (!result)
                return BadRequest();
            return Ok(customer.Id);
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerRepository.Delete(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }

    }
}
