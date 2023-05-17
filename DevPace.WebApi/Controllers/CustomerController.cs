using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Services.Abstractions;

namespace DevPace.WebApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IService _customerService;

        public CustomerController(IService customerService) =>
            _customerService = customerService;

        [HttpGet("{page:int}")]
        public async Task<IActionResult> GetCustomers(int page = 1, [FromQuery] Customer customer = null, CancellationToken cancellationToken = default)
        {
            try
            {
                if (customer == null) customer = new Customer();
                var customers = await _customerService.GetCustomers(page, customer, cancellationToken);

                return Ok(customers);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(string name, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _customerService.GetByNameAsync(name, cancellationToken);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(string name, CancellationToken cancellationToken)
        {
            try
            {
                await _customerService.DeleteAsync(name, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer, CancellationToken cancellationToken)
        {
            var response = await _customerService.CreateAsync(customer, cancellationToken);

            return CreatedAtAction(nameof(GetCustomer), new { name = response.Name });

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _customerService.UpdateAsync(customer, cancellationToken);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
