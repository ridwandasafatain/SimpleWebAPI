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
        public IEnumerable<CustomerResponse> GetAll()
        {
            return _customerService.GetCustomers().Select(a => new CustomerResponse(a));
        }

        [HttpGet("id/{id}")]
        public Response GetByID(int id)
        {
            var res = new Response();
            try
            {
                var result = _customerService.GetCustomerByID(id);
                if (result != null)
                {
                    res.Data = new CustomerResponse(result);
                }
                else
                {
                    res.Message = $"Data dengan id {id} tidak ditemukan"; 
                }
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                return res;
            }           
        }

        [HttpGet("code/{code}")]
        public Response GetByCode(string code)
        {
            var res = new Response();
            try
            {
                var result = _customerService.GetCustomerByCode(code);
                if (result != null)
                {
                    res.Data = new CustomerResponse(result);
                }
                else
                {
                    res.Message = $"Data dengan code {code} tidak ditemukan";
                }
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                return res;
            }            
        }

        [HttpGet("name/{name}")]
        public Response GetByName(string name)
        {
            var res = new Response();
            try
            {
                var result = _customerService.GetCustomerByName(name);
                if(result != null)
                {
                    res.Data = new CustomerResponse(result);
                }
                else
                {
                    res.Message = $"Data dengan nama {name} tidak ditemukan";
                }
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                return res;
            }            
        }

        [HttpPost]
        public IActionResult Insert(InsertCustomerRequest customer)
        {
            try
            {
                _customerService.InsertCustomer(new CustomerDTO(customer));
                return Ok("Data berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public IActionResult Update(UpdateCustomerRequest customer)
        {
            try
            {
                var result = _customerService.GetCustomerByID(customer.CustomerId);
                if (result == null)
                {
                    return BadRequest("Data tidak ditemukan");
                }
                else
                {
                    _customerService.UpdateCustomer(new CustomerDTO(customer));
                    return Ok("Data berhasil diupdate");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
