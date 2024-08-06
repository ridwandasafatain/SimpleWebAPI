using Microsoft.AspNetCore.Mvc;
using Web.Domain;
using Web.Service;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("all")]
        public IEnumerable<CustomerDTO> GetAll()
        {
            return _customerService.GetCustomers();
        }

        [HttpGet("id/{id}")]
        public CustomerDTO GetByID(int id)
        {
            var result = _customerService.GetCustomerByID(id);
            return result == null ? new CustomerDTO() : result;
        }

        [HttpGet("code/{code}")]
        public CustomerDTO GetByCode(string code)
        {
            var result = _customerService.GetCustomerByCode(code);
            return result == null ? new CustomerDTO() : result;
        }

        [HttpGet("name/{name}")]
        public CustomerDTO GetByName(string name)
        {
            var result = _customerService.GetCustomerByName(name);
            return result == null ? new CustomerDTO() : result;
        }

        [HttpPost]
        public IActionResult Insert(CustomerDTO customer)
        {
            _customerService.InsertCustomer(customer);
            return CreatedAtAction("Get", new { id = customer.CustomerId }, customer);
        }

        [HttpPut]
        public IActionResult Update(CustomerDTO customer)
        {
            var result = _customerService.GetCustomerByID(customer.CustomerId);
            if(result == null)
            {
                return BadRequest("Data tidak ditemukan");
            }
            else
            {
                _customerService.UpdateCustomer(customer);
                return Ok(customer);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _customerService.GetCustomerByID(id);
                if(result == null)
                {
                    return BadRequest("Data tidak ditemukan");
                }
                else
                {
                    _customerService.DeleteCustomer(id);
                    return Ok($"Data Customer dengan id {id} berhasil dihapus");
                }                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
