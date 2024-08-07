namespace Web.Domain
{
    public class Response
    {
        public string Message { get; set; } = string.Empty;
        public Guid TransactionId { get; set; } = Guid.NewGuid();
        public CustomerResponse Data { get; set; } = new();
    }
}
