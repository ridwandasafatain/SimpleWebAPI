namespace Web.Domain
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
                
        }

        public CustomerDTO(Customer customer)
        {
            CustomerId = customer.CustomerId;
            CustomerCode = customer.CustomerCode;
            CustomerName = customer.CustomerName;
            CustomerAddress = customer.CustomerAddress;
        }

        public int CustomerId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public int CreatedBy { get; set; } = 0;
        public int? ModifiedBy { get; set; } = null;
    }
}
