using Business.Interface;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;
        
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDTO form)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _customerService.CreateCustomerAsync(form);
            return Ok(result);  
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetCustomersAsync();
            return Ok(result);      
        }
    }
}
