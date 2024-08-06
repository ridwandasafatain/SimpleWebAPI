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
            try
            {
                var result = _customerRepository.GetCustomerByID(id)!;
                _customerRepository.Delete(result);
            }
            catch (Exception)
            {
                throw;
            }
            
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

        public IQueryable<CustomerDTO> GetCustomers()
        {
            return _customerRepository.GetQueryable().Select(a => new CustomerDTO(a));
        }

        public void InsertCustomer(CustomerDTO customer)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            try
            {
                var result = _customerRepository.GetCustomerByID(customer.CustomerId)!;
                result.CustomerCode = customer.CustomerCode;
                result.CustomerName = customer.CustomerName;
                result.CustomerAddress = customer.CustomerAddress;
                result.ModifiedBy = customer.ModifiedBy;

                _customerRepository.Update(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
