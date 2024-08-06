using Web.Domain;

namespace Web.Service
{
    public interface ICustomerService
    {
        void InsertCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerDTO customer);
        void DeleteCustomer(int id);
        CustomerDTO? GetCustomerByID(int id);
        CustomerDTO? GetCustomerByCode(string code);
        CustomerDTO? GetCustomerByName(string name);
        IQueryable<CustomerDTO> GetCustomers();
    }
}
