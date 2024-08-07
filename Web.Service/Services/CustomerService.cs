using Web.Domain;
using Web.Infrastructure;

namespace Web.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void DeleteCustomer(int id)
        {
            var result = _customerRepository.GetCustomerByID(id)!;
            _customerRepository.Delete(result);            
        }

        public CustomerDTO? GetCustomerByCode(string code)
        {
            var result = _customerRepository.GetCustomerByCode(code);
            return result == null ? null : new CustomerDTO(result);
        }

        public CustomerDTO? GetCustomerByID(int id)
        {
            var result = _customerRepository.GetCustomerByID(id);
            return result == null ? null : new CustomerDTO(result);
        }

        public CustomerDTO? GetCustomerByName(string name)
        {
            var result = _customerRepository.GetCustomerByName(name);
            return result == null ? null : new CustomerDTO(result);
        }

        public IList<CustomerDTO> GetCustomers()
        {
            return _customerRepository.GetQueryable().Select(a => new CustomerDTO(a)).ToList();
        }

        public void InsertCustomer(CustomerDTO customer)
        {
            var newCustomer = new Customer()
            {
                CustomerCode = customer.CustomerCode,
                CustomerName = customer.CustomerName,
                CustomerAddress = customer.CustomerAddress,
                CreatedBy = customer.CreatedBy,
            };

            _customerRepository.Add(newCustomer);            
        }

        public void UpdateCustomer(CustomerDTO customer)
        {            
            var result = _customerRepository.GetCustomerByID(customer.CustomerId)!;
            result.CustomerCode = customer.CustomerCode;
            result.CustomerName = customer.CustomerName;
            result.CustomerAddress = customer.CustomerAddress;
            result.ModifiedBy = customer.ModifiedBy;

            _customerRepository.Update(result);                     
        }
    }
}
