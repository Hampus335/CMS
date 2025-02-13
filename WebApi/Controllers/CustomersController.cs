using Business.Interface;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRegistrationForm form)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _customerService.CreateCustomerAsync(form);

            return (object)result.StatusCode switch
            {
                201 => Created("", null),
                400 => BadRequest(result.Message),
                409 => Conflict(result.Message),
                _ => Problem(),
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetCustomerAsync();
            return Ok(result.Result);
        }
    }
}
