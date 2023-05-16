using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetCustomers(int page, CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetCustomers(cancellationToken);

            return Ok(customers);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(string name, CancellationToken cancellationToken)
        {
            var response = await _customerService.GetByNameAsync(name, cancellationToken);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(string name, CancellationToken cancellationToken)
        {
            await _customerService.DeleteAsync(name, cancellationToken);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody]Customer customer, CancellationToken cancellationToken)
        {
            var response = await _customerService.CreateAsync(customer, cancellationToken);

            return CreatedAtAction(nameof(GetCustomer), new { name = response.Name });

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody]Customer customer, CancellationToken cancellationToken)
        {
            var response = await _customerService.UpdateAsync(customer, cancellationToken);
            return Ok(response);
        }

    }
}
