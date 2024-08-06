using Web.Domain;

namespace Web.Infrastructure
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer? GetCustomerByID(int id);
        Customer? GetCustomerByCode(string code);
        Customer? GetCustomerByName(string name);
        IQueryable<Customer> GetCustomerQueryable();
    }
}
