
using Business.Factories;
using Business.Interface;
using Business.Models;
using Data.Interfaces;


namespace Business.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<ResponseResult> CreateCustomerAsync(CustomerDTO form)
        {
            var customerEntity = CustomerFactory.Create(form);
            if (customerEntity == null)
                return ResponseResult.InvalidModel("Model contains invalid values.");

            //kontrollera om kund existerar
            if (await _customerRepository.ExistsAsync(x => x.CustomerName == form.CustomerName))
            
                return ResponseResult.Exists("Customer already exists");

               
                var result = await _customerRepository.AddAsync(customerEntity);
            if (result != 1)
                return ResponseResult.Failed("Customer was not created sucessfully.");

            return ResponseResult.Created("Customer was created successfully.");

        }
        public async Task<ResponseResult<IEnumerable<Customer>>> GetCustomerAsync()
        {
            var enteties = await _customerRepository.GetAllAsync();
            return (ResponseResult<IEnumerable<Customer>>)ResponseResult<IEnumerable<Customer>>.Ok(result: enteties.Select(CustomerFactory.Create)!);
        
        }

        public async Task<ResponseResult<Customer?>> GetCustomerAsync(int id)
        {
            var entity = await _customerRepository.GetAsync(x => x.Id == id);
            return (ResponseResult<Customer?>)(entity == null
                ? ResponseResult<Customer?>.NotFound("Customer was not found.")
                : ResponseResult<Customer?>.Ok(result: CustomerFactory.Create(entity)));

        }

        public async Task<ResponseResult<Customer?>> GetCustomerAsync(string customerName)
        {
            var entity = await _customerRepository.GetAsync(x => x.CustomerName == customerName);
            return (ResponseResult<Customer?>)(entity == null
                ? ResponseResult<Customer?>.NotFound("Customer was not found.")
                : ResponseResult<Customer?>.Ok(result: CustomerFactory.Create(entity)));
        }
    }
}
