using Web.Domain;

namespace Web.Infrastructure
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {
                
        }

        public Customer? GetCustomerByCode(string code)
        {
            return GetQueryable(a => a.CustomerCode == code).FirstOrDefault();
        }

        public Customer? GetCustomerByID(int id)
        {
            return GetQueryable(a => a.CustomerId == id).FirstOrDefault();
        }

        public Customer? GetCustomerByName(string name)
        {
            return GetQueryable(a => a.CustomerName == name).FirstOrDefault();
        }

        public IQueryable<Customer> GetCustomerQueryable()
        {
            return GetQueryable();
        }
    }
}
