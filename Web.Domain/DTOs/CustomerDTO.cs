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

        public CustomerDTO(InsertCustomerRequest customer)
        {
            CustomerCode = customer.CustomerCode;
            CustomerName = customer.CustomerName;
            CustomerAddress = customer.CustomerAddress;
            CreatedBy = customer.CreatedBy;
        }

        public CustomerDTO(UpdateCustomerRequest customer)
        {
            CustomerId = customer.CustomerId;
            CustomerCode = customer.CustomerCode;
            CustomerName = customer.CustomerName;
            CustomerAddress = customer.CustomerAddress;
            ModifiedBy = customer.ModifiedBy;
        }

        public int CustomerId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public int CreatedBy { get; set; } = 0;
        public int? ModifiedBy { get; set; } = null;
    }

    public class CustomerResponse
    {
        public CustomerResponse()
        {
                
        }

        public CustomerResponse(CustomerDTO customer)
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
    }

    public class InsertCustomerRequest
    {
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public int CreatedBy { get; set; } = 0;
    }

    public class UpdateCustomerRequest
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public int ModifiedBy { get; set; } = 0;
    }
}
